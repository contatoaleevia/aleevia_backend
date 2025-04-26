using Api.ApiResponses;
using Domain.Exceptions;
using Newtonsoft.Json;

namespace Api.Middlewares;

public class ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        LogException(exception);
        
        var response = CreateResponse(exception);
        var statusCode = DetermineStatusCode(exception);
        
        await WriteResponseAsync(context, response, statusCode);
    }

    private static ApiProblemDetails CreateResponse(Exception exception)
    {
        return exception switch
        {
            ApiException apiException => ApiProblemDetails.CreateApiProblemDetails(apiException),
            _ => ApiProblemDetails.CreateApiProblemDetails(exception)
        };
    }

    private static int DetermineStatusCode(Exception exception)
    {
        return exception switch
        {
            ApiException apiException => apiException.StatusCode,
            _ => 500
        };
    }

    private static async Task WriteResponseAsync(HttpContext context, ApiProblemDetails response, int statusCode)
    {
        var serializedResponse = JsonConvert.SerializeObject(response);
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;
        
        await context.Response.WriteAsync(serializedResponse);
    }

    private void LogException(Exception exception)
    {
        logger.LogError(exception, "An error occurred during request processing");
        WriteExceptionToConsole(exception);
    }

    private static void WriteExceptionToConsole(Exception exception)
    {
        Console.WriteLine("One error occurred:");
        Console.WriteLine("Name: {0}", exception.GetType().Name);
        Console.WriteLine("Message:\n {0}\n", exception.Message);
        Console.WriteLine("Stack Trace:\n {0}\n", exception.StackTrace);
    }
}