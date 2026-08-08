using LibraryManagementSystem.API.Exceptions;
using LibraryManagementSystem.API.Responses;
using System.Net;
using System.Text.Json;

namespace LibraryManagementSystem.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
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

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var response = new ErrorResponse();

            switch (exception)
            {
                case NotFoundException:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    response.StatusCode = StatusCodes.Status404NotFound;
                    response.Message = exception.Message;
                    break;

                case BadRequestException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    response.Message = exception.Message;
                    break;

                case UnauthorizedException:
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    response.StatusCode = StatusCodes.Status401Unauthorized;
                    response.Message = exception.Message;
                    break;

                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    response.Message = "An unexpected error occurred.";
                    break;
            }

            var json = JsonSerializer.Serialize(response);

            await context.Response.WriteAsync(json);
        }
    }
}