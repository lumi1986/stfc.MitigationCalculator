using MediatR;
using stfc.MitigationCalculator.Application.Services;
using stfc.MitigationCalculator.Common.Models;
using stfc.MitigationCalculator.Common.Requests;

namespace stfc.MitigationCalculator.Application.Handlers;

internal class CalculateByValuesHandler : CalculateBaseHandler, IRequestHandler<CalculateByValueRequest, Mitigation>
{
    public CalculateByValuesHandler(RatioLogisticFunctionService ratioLogisticFunctionService, DefenderTypeWeightFactorsService defenderTypeWeightFactorsService)
        : base(ratioLogisticFunctionService, defenderTypeWeightFactorsService)
    {
    }
    
    public Task<Mitigation> Handle(CalculateByValueRequest request, CancellationToken cancellationToken)
    {
        var mitigation = new Mitigation { MitigationInPercentage = CalculateMitigation(request.Payload) } ;
        
        return Task.FromResult(mitigation);
    }
}