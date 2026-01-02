using Microsoft.AspNetCore.Http;
using PRService.API.Contracts.Common;
using PRService.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace PRService.API.Middleware
{
    public sealed class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
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
            catch (InvalidStatusTransitionException ex)
            {
                await HandleException(
                    context,
                    HttpStatusCode.BadRequest,
                    "INVALID_OPERATION",
                    ex.Message
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");

                await HandleException(
                    context,
                    HttpStatusCode.InternalServerError,
                    "INTERNAL_SERVER_ERROR",
                    "Something went wrong"
                );
            }
        }

        private static async Task HandleException(HttpContext context, HttpStatusCode statusCode, string code, string message)
        {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)statusCode;

                var response = new ErrorResponse(code, message);

                await context.Response.WriteAsync(
                    JsonSerializer.Serialize(response));
        }
    }
}
