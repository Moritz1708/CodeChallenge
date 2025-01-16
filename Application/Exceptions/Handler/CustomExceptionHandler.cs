namespace Application.Exceptions.Handler;

public class CustomExceptionHandler(ILogger<CustomExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError("{Time} Error : {Message}", exception.Message, DateTime.UtcNow);   
        
        (string Details, string Title, int StatusCode) details = exception switch
        {
            ValidationException => 
            (
                exception.Message, 
                exception.GetType().Name, 
                context.Response.StatusCode = StatusCodes.Status400BadRequest
            ),
            EventNotFoundException => 
            (
                exception.Message, 
                exception.GetType().Name, 
                context.Response.StatusCode = StatusCodes.Status404NotFound
            ),
            AutoMapperMappingException =>
            (
                exception.Message, 
                exception.GetType().Name, 
                context.Response.StatusCode = StatusCodes.Status400BadRequest
            ),
            _ => 
            (
                exception.Message, 
                exception.GetType().Name, 
                context.Response.StatusCode = StatusCodes.Status500InternalServerError
            )
        };
        
        var problemDetails = new ProblemDetails
        {
            Title = details.Title,
            Detail = details.Details,
            Status = details.StatusCode,
            Instance = context.Request.Path
        };
        
        problemDetails.Extensions.Add("traceId", context.TraceIdentifier);
        
        if(exception is ValidationException validationException)
        {
            problemDetails.Extensions.Add("ValidationErrors", validationException.Errors);
        }
        
        var json = JsonConvert.SerializeObject(problemDetails);
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(json, cancellationToken: cancellationToken);
        
        return true;
    }
}