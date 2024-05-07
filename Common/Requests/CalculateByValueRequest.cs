using MediatR;
using stfc.MitigationCalculator.Common.Models;

namespace stfc.MitigationCalculator.Common.Requests;

public class CalculateByValueRequest : IRequest<Mitigation>
{

}