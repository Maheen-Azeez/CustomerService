using CustomerService.Application.DTOs.Errors;
using CustomerService.Application.DTOs.Responses;
using System.Net;
using System.Text.Json;

namespace CustomerService.API.Middlewares
{
    public class GlobalExceptionHandlingMiddleware 
    {
        private readonly RequestDelegate next;
        private readonly ILogger<GlobalExceptionHandlingMiddleware> logger;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception: {ex.Message}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, ErrorDto errorDto)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = errorDto.StatusCode;

            var result = JsonSerializer.Serialize(errorDto);
            return context.Response.WriteAsync(result);
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exception switch
            {
                KeyNotFoundException => (int)HttpStatusCode.NotFound,
                ArgumentException => (int)HttpStatusCode.BadRequest,
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                _ => (int)HttpStatusCode.InternalServerError
            };

            var response = new ApiResponse<ErrorDto>(
                success: false,
                message: exception.Message,
                data: null
            );

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

    }
}
