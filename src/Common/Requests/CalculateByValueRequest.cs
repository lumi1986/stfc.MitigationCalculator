using MediatR;
using stfc.MitigationCalculator.Common.Models;

namespace stfc.MitigationCalculator.Common.Requests;

public class CalculateByValueRequest : IRequest<Mitigation>
{
    public CalculateByValueRequest(MitigationByValues payload)
    {
        Payload = payload ?? throw new InvalidOperationException();
    }

    public MitigationByValues Payload { get; } = null!;
}