using stfc.MitigationCalculator.Application.Services;
using stfc.MitigationCalculator.Common.Models;

namespace stfc.MitigationCalculator.Application.Handlers;

internal abstract class CalculateBaseHandler
{
    private readonly DefenderTypeWeightFactorsService _defenderTypeWeightFactorsService;
    private readonly RatioLogisticFunctionService _ratioLogisticFunctionService;

    protected CalculateBaseHandler(RatioLogisticFunctionService ratioLogisticFunctionService, DefenderTypeWeightFactorsService defenderTypeWeightFactorsService)
    {
        _ratioLogisticFunctionService = ratioLogisticFunctionService;
        _defenderTypeWeightFactorsService = defenderTypeWeightFactorsService;
    }

    protected double CalculateMitigation(MitigationByValues values, double defenseOfficer = 0.0)
    {
        //m = 1 - (1 - wa * 1 / (1 + 4 ^ (1.1 - (as + ao) / ap))) * (1 - ws * 1 / (1 + 4 ^ (1.1 - (ss + so) / sp))) * (1 - wd * 1 / (1 + 4 ^ (1.1 - (ds + do) / a)))
        var mitigation = 1.0 - (CalculateArmorPart(values, defenseOfficer) * CalculateShieldPart(values, defenseOfficer) * CalculateDodgePart(values, defenseOfficer));
        return mitigation;
    }

    protected double CalculateArmorPart(MitigationByValues values, double defenseOfficer = 0.0)
    {
        var weightFactors = GetWeightFactors(values);
        return CalculatePart(weightFactors.ArmorFactor, values.Attacker.ArmorPiercing, values.Defender.Armor, defenseOfficer);
    }

    protected double CalculateShieldPart(MitigationByValues values, double defenseOfficer = 0.0)
    {
        var weightFactors = GetWeightFactors(values);
        return CalculatePart(weightFactors.ShieldFactor, values.Attacker.ShieldPiercing, values.Defender.ShieldDeflection, defenseOfficer);
    }

    protected double CalculateDodgePart(MitigationByValues values, double defenseOfficer = 0.0)
    {
        var weightFactors = GetWeightFactors(values);
        return CalculatePart(weightFactors.DodgeFactor, values.Attacker.Accuracy, values.Defender.Dodge, defenseOfficer);
    }

    protected DefenderTypeWeightFactors GetWeightFactors(MitigationByValues values)
    {
        return _defenderTypeWeightFactorsService.GetWeightFactors(values.Defender.Type);
    }

    protected double CalculatePart(double weightFactor, double attack, double defenseShip, double defenseOfficer = 0.0)
    {
        return 1.0 - (weightFactor * _ratioLogisticFunctionService.CalculateValueByRatio((defenseShip + defenseOfficer) / attack));
    }
}