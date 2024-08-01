using TaskManager.Core.Module.Exceptions;
using TaskManager.Core.Module.Utils;
using TaskManager.Dto;

namespace TaskManager.Middlewares
{

    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
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
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            switch (exception)
            {
                case EntityNotFoundException:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    return context.Response.WriteAsJsonAsync(new DefaultResponse<Unit>(exception.Message));

                //case UniqueConstraintException:
                //case MismatchException:
                //    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                //    return context.Response.WriteAsJsonAsync(new DefaultResponse<Unit>(exception.Message));

                case InvalidCredentialsException:
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return context.Response.WriteAsJsonAsync(new DefaultResponse<Unit>(exception.Message));

                default:
                    _logger.LogError(exception.Message);
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    return context.Response.WriteAsJsonAsync(new DefaultResponse<Unit>("An unexpected error occurred."));
            }
        }
    }
}
