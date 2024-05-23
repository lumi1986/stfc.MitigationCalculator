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
    public class CalculateMitigationByValuesController
    {
        private readonly ILogger<CalculateMitigationByValuesController> _logger;
        private readonly IMediator _mediator;

        public CalculateMitigationByValuesController(ILogger<CalculateMitigationByValuesController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [Function("CalculateByValues")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")]
            [RequestBodyType(typeof(MitigationByValues), "product request")]HttpRequest httpRequest)
        {   
            var request = await httpRequest.ReadFromJsonAsync<MitigationByValues>();
            
            var result = await _mediator.Send(new CalculateByValueRequest(request));
            
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult(result);
        }
    }
}