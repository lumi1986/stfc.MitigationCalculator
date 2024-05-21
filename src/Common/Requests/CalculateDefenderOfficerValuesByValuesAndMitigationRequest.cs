using MediatR;
using stfc.MitigationCalculator.Common.Models;

namespace stfc.MitigationCalculator.Common.Requests;

public class CalculateDefenderOfficerValuesByValuesAndMitigationRequest : IRequest<OfficerValues>
{
    public CalculateDefenderOfficerValuesByValuesAndMitigationRequest(DefenderOfficerValuesByValuesAndMitigation payload)
    {
        Payload = payload;
    }

    public DefenderOfficerValuesByValuesAndMitigation Payload { get; }
}