// using System;
// using Intact.DynamicRendering.Services.AtVantage;
// using System.Collections.Generic;
// using System.Net.Mime;
// using System.Threading.Tasks;
// using Intact.DynamicRendering.Net;
// using Intact.DynamicRendering.Services;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Azure.Functions.Worker;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.Logging;
// using Newtonsoft.Json;

// namespace Intact.DynamicRendering.Functions;

// public class AtVantageApi(
//     IConfiguration configuration,
//     IAtVantageService atVantageService,
//     ILogger<AtVantageApi> logger
// )
// {
//     private readonly IConfiguration _configuration = configuration;
//     private readonly IAtVantageService _atVantageService = atVantageService;
//     private readonly ILogger<AtVantageApi> _logger = logger;

//     [Function("AtVantageApi")]
//     public async Task<IActionResult> Run(
//         [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req
//        )
//     {
//         var functionName = nameof(AtVantageApi);

//         try
//         {
//             _logger.LogInformation($"{functionName}::Run");

//             string? baseUrl = _configuration["DR_JARUS_PRODUCT_SOURCE_HOST"];
//             string? objectName = req.Query["objectName"];
//             string objectType = req.Query["objectType"];
//             var intactComponents = await _atVantageService.GetIntactComponents(baseUrl, objectName, objectType);

//             var finalUnqorkComponents = new List<UnqorkComponent>();

//             var finalJson = JsonConvert.SerializeObject(finalUnqorkComponents, Formatting.Indented, ObjectTypeConverter.UnqorkComponentConverter.Settings);

//             _logger.LogInformation($"{functionName}::Success");

//             return new ContentResult
//             {
//                 Content = finalJson,
//                 ContentType = MediaTypeNames.Application.Json,
//                 StatusCode = 200
//             };
//         }
//         catch (ArgumentException ex)
//         {
//             _logger.LogError($"{functionName}::ValidationError {ex.Message}", ex.StackTrace);
//             return new BadRequestObjectResult(ex.Message);
//         }
//         catch (Exception ex)
//         {
//             _logger.LogError($"{functionName}::Error {ex.Message}", ex.StackTrace);
//             return new InternalServerErrorObjectResult(ex);
//         }
//     }
// }
