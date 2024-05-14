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
    public class CalculateByValuesController
    {
        private readonly ILogger<CalculateByValuesController> _logger;
        private readonly IMediator _mediator;

        public CalculateByValuesController(ILogger<CalculateByValuesController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [Function("CalculateByValues")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")]
            [RequestBodyType(typeof(MitigationByValueRequest), "product request")]HttpRequest httpRequest)
        {   
            var request = await httpRequest.ReadFromJsonAsync<MitigationByValueRequest>();
            
            var result = await _mediator.Send(new CalculateByValueRequest(request));
            
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult(result);
        }
    }
}
