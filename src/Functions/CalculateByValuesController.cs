using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stfc.MitigationCalculator.Common.Models;
using AzureFunctions.Extensions.Swashbuckle.Attribute;

namespace Functions
{
    public class CalculateByValuesController
    {
        private readonly ILogger<CalculateByValuesController> _logger;

        public CalculateByValuesController(ILogger<CalculateByValuesController> logger)
        {
            _logger = logger;
        }

        [Function("CalculateByValues")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")]
            [RequestBodyType(typeof(MitigationByValueRequest), "product request")]HttpRequest httpRequest)
        {   
            var request = await httpRequest.ReadFromJsonAsync<MitigationByValueRequest>();
            
            
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
