using Microsoft.AspNetCore.Diagnostics;

namespace GlobalExceptionHadling
{
    public class AppExceptionHandler(ILogger<AppExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            if(exception is NotImplementedException)
            {
                logger.LogError(exception, exception.Message);
                var reponse = new ErrorResponse
                {
                    StatusCode = StatusCodes.Status501NotImplemented,
                    ExceptionMessage = exception.Message,
                    Title = "Something get Wrong"
                };

            await httpContext.Response.WriteAsJsonAsync("Something get Wrong");
            httpContext.Response.StatusCode = StatusCodes.Status501NotImplemented;
                return (true);
            }

            return false;

        }
    }
}
