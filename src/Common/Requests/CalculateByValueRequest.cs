using MediatR;
using stfc.MitigationCalculator.Common.Models;

namespace stfc.MitigationCalculator.Common.Requests;

public class CalculateByValueRequest : IRequest<Mitigation>
{
    public CalculateByValueRequest(MitigationByValueRequest payload)
    {
        Payload = payload;
    }

    public MitigationByValueRequest Payload { get; }
}