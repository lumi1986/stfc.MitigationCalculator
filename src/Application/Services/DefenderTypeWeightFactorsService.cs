using stfc.MitigationCalculator.Common.Models;

namespace stfc.MitigationCalculator.Application.Services;

internal class DefenderTypeWeightFactorsService
{
    private readonly Dictionary<DefenderType, DefenderTypeWeightFactors> _weightFactors = new Dictionary<DefenderType, DefenderTypeWeightFactors>
    {
        { DefenderType.Explorer, new DefenderTypeWeightFactors { ShieldFactor = 0.55, ArmorFactor = 0.2, DodgeFactor = 0.2 } },
        { DefenderType.Battleship, new DefenderTypeWeightFactors { ShieldFactor = 0.2, ArmorFactor = 0.55, DodgeFactor = 0.2 } },
        { DefenderType.Interceptor, new DefenderTypeWeightFactors { ShieldFactor = 0.2, ArmorFactor = 0.2, DodgeFactor = 0.55 } },
        { DefenderType.Survey, new DefenderTypeWeightFactors { ShieldFactor = 0.3, ArmorFactor = 0.3, DodgeFactor = 0.3 } },
        { DefenderType.Armada, new DefenderTypeWeightFactors { ShieldFactor = 0.3, ArmorFactor = 0.3, DodgeFactor = 0.3 } },
    };

    public DefenderTypeWeightFactors GetWeightFactors(DefenderType type) => _weightFactors[type];
} 