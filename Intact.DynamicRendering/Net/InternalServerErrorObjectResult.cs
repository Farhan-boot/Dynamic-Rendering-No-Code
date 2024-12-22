using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Intact.DynamicRendering.Net;

public class InternalServerErrorObjectResult : ObjectResult
{
    public InternalServerErrorObjectResult(object value)
        : base(value)
    {
        StatusCode = StatusCodes.Status500InternalServerError;
    }

    public InternalServerErrorObjectResult(Exception ex)
        : this(new
        {
            details = $"{ex.Message} - {ex.InnerException?.Message}",
            statusText = "Internal Server Error"
        })
    {
    }
}
