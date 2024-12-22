using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Intact.DynamicRendering.Services.AtVantage;
using Intact.DynamicRendering.Components.Unqork;

namespace Intact.DynamicRendering.Functions;

public class LocalJson(IAtVantageService atVantageService, ILogger<LocalJson> logger)
{
    private readonly IAtVantageService _atVantageService = atVantageService;
    private readonly ILogger<LocalJson> _logger = logger;

    [Function("LocalJson")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req)
    {
        var requestBody = string.Empty;

        try
        {
            requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            if (string.IsNullOrEmpty(requestBody))
            {
                return new BadRequestObjectResult("Request body is empty.");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred in reading the body.");
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
        var finalJson = "";

        try
        {
            var finalUnqorkComponents = _atVantageService.GetUnqorkComponents();
            finalJson = JsonConvert.SerializeObject(finalUnqorkComponents, Formatting.Indented, ObjectTypeConverter.UnqorkComponentConverter.Settings);
        }
        catch (JsonReaderException ex)
        {
            _logger.LogError(ex, "Invalid JSON format.");
            return new BadRequestObjectResult("Invalid JSON format.");
        }
        catch (JsonSerializationException ex)
        {
            _logger.LogError(ex, "An error occurred while deserializing Json.");
            return new BadRequestObjectResult("Invalid JSON format.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while deserializing Json.");
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }


        // Return the final JSON response
        return new ContentResult
        {
            Content = finalJson,
            ContentType = "application/json",
            StatusCode = 200
        };


    }
}
