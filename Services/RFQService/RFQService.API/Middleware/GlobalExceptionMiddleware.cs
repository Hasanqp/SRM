using Microsoft.AspNetCore.Mvc;
using RFQService.Domain.Exceptions;
using System.Text.Json;

namespace RFQService.API.Middleware
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

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleException(context, ex);
            }
        }

        private static async Task HandleException(HttpContext context, Exception exception)
        {
            var problem = exception switch
            {
                NotFoundException ex => CreateProblem(
                    StatusCodes.Status404NotFound,
                    "Not Found",
                    ex.Message
                ),

                InvalidRFQStateException ex => CreateProblem(
                    StatusCodes.Status409Conflict,
                    "Invalid RFQ State",
                    ex.Message
                ),

                DomainException ex => CreateProblem(
                    StatusCodes.Status400BadRequest,
                    "Domain Error",
                    ex.Message
                ),

                _ => CreateProblem(
                    StatusCodes.Status500InternalServerError,
                    "Internal Server Error",
                    "Something went wrong"
                )
            };

            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = problem.Status!.Value;

            var json = JsonSerializer.Serialize(problem);
            await context.Response.WriteAsync(json);
        }

        private static ProblemDetails CreateProblem(
            int status,
            string title,
            string detail)
        {
            return new ProblemDetails
            {
                Status = status,
                Title = title,
                Detail = detail
            };
        }
    }
}
