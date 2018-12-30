using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

namespace FunctionApp
{
    public static class LocaleHttpTrigger
    {
        [FunctionName(nameof(Default))]
        public static async Task<IActionResult> Default(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "locale/default")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var body = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(body);

            var date = (string)data.date;
            var converted = DateTimeOffset.TryParse(date, out DateTimeOffset result) ? result : DateTimeOffset.MinValue;

            return (ActionResult)new OkObjectResult($"Input: {converted:O}");
        }

        [FunctionName(nameof(KoKr))]
        public static async Task<IActionResult> KoKr(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "locale/ko-kr")] HttpRequest req,
            ILogger log)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("ko-KR");

            log.LogInformation("C# HTTP trigger function processed a request.");

            var body = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(body);

            var date = (string)data.date;
            var converted = DateTimeOffset.TryParse(date, out DateTimeOffset result) ? result : DateTimeOffset.MinValue;

            return (ActionResult)new OkObjectResult($"Input: {converted:O}");
        }

        [FunctionName(nameof(EnUs))]
        public static async Task<IActionResult> EnUs(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "locale/en-us")] HttpRequest req,
            ILogger log)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            log.LogInformation("C# HTTP trigger function processed a request.");

            var body = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(body);

            var date = (string)data.date;
            var converted = DateTimeOffset.TryParse(date, out DateTimeOffset result) ? result : DateTimeOffset.MinValue;

            return (ActionResult)new OkObjectResult($"Input: {converted:O}");
        }

        [FunctionName(nameof(EnAu))]
        public static async Task<IActionResult> EnAu(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "locale/en-au")] HttpRequest req,
            ILogger log)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-AU");

            log.LogInformation("C# HTTP trigger function processed a request.");

            var body = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(body);

            var date = (string)data.date;
            var converted = DateTimeOffset.TryParse(date, out DateTimeOffset result) ? result : DateTimeOffset.MinValue;

            return (ActionResult)new OkObjectResult($"Input: {converted:O}");
        }
    }
}