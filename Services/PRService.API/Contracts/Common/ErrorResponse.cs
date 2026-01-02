namespace PRService.API.Contracts.Common
{
    public sealed record ErrorResponse(
        string Code,
        string Message,
        object? Details = null
    );        
}
