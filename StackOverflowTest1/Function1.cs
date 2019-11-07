using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace StackOverflowTest1
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            string name = req.Query["name"];
            var cp = Process.GetCurrentProcess();
            log.LogInformation($"ÅöFunction1 NORMAL PID = {cp.Id}, PName = {cp.ProcessName}, Machine = {cp.MachineName}Å@ {name}. at {DateTime.UtcNow}");

            return name != null
                ? (ActionResult)new OkObjectResult($"Hello, {name}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
