using MediatR;
using stfc.MitigationCalculator.Application.Services;
using stfc.MitigationCalculator.Common.Models;
using stfc.MitigationCalculator.Common.Requests;

namespace stfc.MitigationCalculator.Application.Handlers;

internal class CalculateByValuesHandler : IRequestHandler<CalculateByValueRequest, Mitigation>
{
    private readonly DefenderTypeWeightFactorsService _defenderTypeWeightFactorsService;
    private readonly RatioLogisticFunctionService _ratioLogisticFunctionService;

    public CalculateByValuesHandler(RatioLogisticFunctionService ratioLogisticFunctionService, DefenderTypeWeightFactorsService defenderTypeWeightFactorsService)
    {
        _ratioLogisticFunctionService = ratioLogisticFunctionService;
        _defenderTypeWeightFactorsService = defenderTypeWeightFactorsService;
    }
    
    public Task<Mitigation> Handle(CalculateByValueRequest request, CancellationToken cancellationToken)
    {
        var weightFactors = _defenderTypeWeightFactorsService.GetWeightFactors(request.Payload.Defender.Type);

        var mitigation = new Mitigation { MitigationInPercentage = 1 - (CalculateArmorPart(request.Payload.Attacker, request.Payload.Defender, weightFactors) * CalculateShieldPart(request.Payload.Attacker, request.Payload.Defender, weightFactors) * CalculateDodgePart(request.Payload.Attacker, request.Payload.Defender, weightFactors))};
        
        return Task.FromResult(mitigation);
    }

    private double CalculateArmorPart(AttackerValues attacker, DefenderValues defender, DefenderTypeWeightFactors weightFactors)
    {
        return CalculatePart(attacker.ArmorPiercing, defender.Armor, weightFactors.ArmorFactor);
    }

    private double CalculateShieldPart(AttackerValues attacker, DefenderValues defender, DefenderTypeWeightFactors weightFactors)
    {
        return CalculatePart(attacker.ShieldPiercing, defender.ShieldDeflection, weightFactors.ShieldFactor);
    }

    private double CalculateDodgePart(AttackerValues attacker, DefenderValues defender, DefenderTypeWeightFactors weightFactors)
    {
        return CalculatePart(attacker.Accuracy, defender.Dodge, weightFactors.DodgeFactor);
    }

    private double CalculatePart(double attack, double defense, double weightFactor)
    {
        return 1.0 - (weightFactor * _ratioLogisticFunctionService.Calculate(defense / attack));
    }

}