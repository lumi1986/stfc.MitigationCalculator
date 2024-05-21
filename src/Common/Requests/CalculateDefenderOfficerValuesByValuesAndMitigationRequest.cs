using MediatR;
using stfc.MitigationCalculator.Common.Models;

namespace stfc.MitigationCalculator.Common.Requests;

public class CalculateDefenderOfficerValuesByValuesAndMitigationRequest : IRequest<OfficerValues>
{
    public CalculateDefenderOfficerValuesByValuesAndMitigationRequest(DefenderOfficerValuesByValuesAndMitigation payload)
    {
        Payload = payload ?? throw new InvalidOperationException();
    }

    public DefenderOfficerValuesByValuesAndMitigation Payload { get; } = null!;
}