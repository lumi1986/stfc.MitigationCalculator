using MathNet.Numerics;
using MediatR;
using stfc.MitigationCalculator.Application.Services;
using stfc.MitigationCalculator.Common.Models;
using stfc.MitigationCalculator.Common.Requests;

namespace stfc.MitigationCalculator.Application.Handlers;

internal class CalculateByMitigationAndAttackerValues : CalculateBaseHandler, IRequestHandler<CalculateDefenderOfficerValuesByValuesAndMitigationRequest, OfficerValues>
{
    
    public CalculateByMitigationAndAttackerValues(RatioLogisticFunctionService ratioLogisticFunctionService, DefenderTypeWeightFactorsService defenderTypeWeightFactorsService)
        : base (ratioLogisticFunctionService, defenderTypeWeightFactorsService)
    {
    }
    
    public Task<OfficerValues> Handle(CalculateDefenderOfficerValuesByValuesAndMitigationRequest request, CancellationToken cancellationToken)
    {
        Func<double, double> equation = o => CalculateMitigation(request.Payload, o) - request.Payload.Mitigation;

        double solution = FindRoots.OfFunction(equation, 0, 100000000);

        var result = new OfficerValues 
        { 
            Armor =  solution,
            ShieldDeflection = solution,
            Dodge = solution
        };

        return Task.FromResult(result);
    }
}