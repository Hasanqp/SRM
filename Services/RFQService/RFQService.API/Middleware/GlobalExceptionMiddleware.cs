using Microsoft.AspNetCore.Mvc;
using RFQService.Domain.Exceptions;
using System.Text.Json;

namespace RFQService.API.Middleware
{
    public sealed class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private static async Task HandleException(
            HttpContext context,
            Exception exception)
        {
            var problem = exception switch
            {
                NotFoundException notFound =>
                    CreateProblem(
                        StatusCodes.Status404NotFound,
                        "Resource not found",
                        notFound.Message),

                DomainException domain =>
                    CreateProblem(
                        StatusCodes.Status409Conflict,
                        "Domain rule violation",
                        domain.Message),

                _ =>
                    CreateProblem(
                        StatusCodes.Status500InternalServerError,
                        "Internal server error",
                        "An unexpected error occurred")
            };

            context.Response.StatusCode = problem.Status!.Value;
            context.Response.ContentType = "application/problem+json";

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(problem));
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
