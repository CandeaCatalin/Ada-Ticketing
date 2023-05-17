using System.Net;
using System.Text.Json;

namespace BegaAir.TicketsManagementMicroservice.REST.Middleware;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await ConvertException(context, ex);
        }
    }

    private Task ConvertException(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var result = string.Empty;
        HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
                var id = context.TraceIdentifier;
                result = JsonSerializer.Serialize(new { Error = exception.Message, TraceId = id });
           
        context.Response.StatusCode = (int)(httpStatusCode);

        if (result == string.Empty)
        {
            result = JsonSerializer.Serialize(new { Error = exception.Message });
        }

        return context.Response.WriteAsync(result);
    }
}