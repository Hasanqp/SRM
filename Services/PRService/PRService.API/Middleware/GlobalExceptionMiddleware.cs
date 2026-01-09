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
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var (statusCode, response) = exception switch
            {
                // 409 Conflict
                InvalidStatusTransitionException ex => (
                    HttpStatusCode.Conflict,
                    new ErrorResponse(
                        "INVALID_STATUS_TRANSITION",
                        ex.Message
                    )
                ),

                // 404 Not Found
                NotFoundException ex => (
                    HttpStatusCode.NotFound,
                    new ErrorResponse(
                        "NOT_FOUND",
                        ex.Message
                    )
                ),

                // 400 Bad Request
                DomainException ex => (
                    HttpStatusCode.BadRequest,
                    new ErrorResponse(
                        "DOMAIN_ERROR",
                        ex.Message
                    )
                ),

                // 500 Internal Server Error
                _ => (
                    HttpStatusCode.InternalServerError,
                    new ErrorResponse(
                        "INTERNAL_SERVER_ERROR",
                        "Something went wrong"
                    )
                )
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response));
        }
    }
}
