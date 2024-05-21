using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stfc.MitigationCalculator.Common.Models;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
using MediatR;
using stfc.MitigationCalculator.Common.Requests;

namespace Functions
{
    public class CalculateDefenderOfficerValuesByValuesAndMitigationController
    {
        private readonly ILogger<CalculateDefenderOfficerValuesByValuesAndMitigationController> _logger;
        private readonly IMediator _mediator;

        public CalculateDefenderOfficerValuesByValuesAndMitigationController(ILogger<CalculateDefenderOfficerValuesByValuesAndMitigationController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [Function("CalculateDefenderOfficerValuesByValuesAndMitigation")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")]
            [RequestBodyType(typeof(DefenderOfficerValuesByValuesAndMitigation), "product request")]HttpRequest httpRequest)
        {   
            var request = await httpRequest.ReadFromJsonAsync<DefenderOfficerValuesByValuesAndMitigation>();
            
            var result = await _mediator.Send(new CalculateDefenderOfficerValuesByValuesAndMitigationRequest(request));
            
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult(result);
        }
    }
}