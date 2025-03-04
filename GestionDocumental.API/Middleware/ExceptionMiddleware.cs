using System.Net;
using System.Text.Json;

namespace GestionDocumental.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error inesperado.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var errorResponse = new
            {
                message = exception.Message,
                statusCode = (int)HttpStatusCode.InternalServerError,
                detail = exception.StackTrace
            };

            response.StatusCode = errorResponse.statusCode;
            return response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }
    }
}