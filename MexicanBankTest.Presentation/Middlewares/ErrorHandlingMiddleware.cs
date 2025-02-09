using Newtonsoft.Json;
namespace MexicanBankTest.Presentation.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            await HandleExceptionAsync(context, e);
        }
    }
    
    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        int statusCode;
        string message;

        context.Response.ContentType = "application/json";

        switch (exception)
        {
            default:
                statusCode = 500;
                message = exception.Message;
                break;
        }

        var errorDetails = new
        {
            Message = message,
            Detail = exception.Message
        };
        
        context.Response.StatusCode = statusCode;
        return context.Response.WriteAsync(JsonConvert.SerializeObject(errorDetails));
    }
}