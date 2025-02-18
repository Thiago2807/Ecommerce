using ecommerce_core.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace ecommerce_core.Exceptions;

public class ExceptionHandlerCustom : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        int statusCode;
        string message;

        switch (exception)
        {
            case NotFoundExceptionCustom:
                statusCode = StatusCodes.Status404NotFound;
                message = exception.Message;
                break;
            case BadRequestExceptionCustom:
                statusCode = StatusCodes.Status400BadRequest;
                message = exception.Message;
                break;
            default:
                statusCode = StatusCodes.Status500InternalServerError;
                message = exception.Message;
                break;
        }

        // Configurar a resposta HTTP
        httpContext.Response.StatusCode = statusCode;
        httpContext.Response.ContentType = "application/json";

        ResponseApp<object> response = new()
        {
            Error = true,
            Message = message
        };

        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

        return true;
    }
}
