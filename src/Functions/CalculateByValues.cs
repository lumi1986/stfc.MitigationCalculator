using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Functions
{
    public class CalculateByValues
    {
        private readonly ILogger<CalculateByValues> _logger;

        public CalculateByValues(ILogger<CalculateByValues> logger)
        {
            _logger = logger;
        }

        [Function("CalculateByValues")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
