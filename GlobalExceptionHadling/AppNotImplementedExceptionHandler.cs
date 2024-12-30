using Microsoft.AspNetCore.Diagnostics;

namespace GlobalExceptionHadling
{
    public class AppNotImplementedExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            if(exception is NotImplementedException)
            {
            var reponse = new ErrorResponse
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                ExceptionMessage = exception.Message,
                Title = "Something get Wrong"
            };

            await httpContext.Response.WriteAsJsonAsync("Something get Wrong");
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            return (true);

            }
            return false;
        }
    }
}
