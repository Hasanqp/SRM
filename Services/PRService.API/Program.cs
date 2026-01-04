using Microsoft.AspNetCore.Authentication;
using PRService.API.Auth;
using PRService.API.Middleware;
using PRService.Application;
using PRService.Domain.Constants;
using PRService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add MediatR
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

// Authentication (Fake – temporary)
builder.Services.AddAuthentication("Fake")
    .AddScheme<AuthenticationSchemeOptions, FakeAuthenticationHandler>(
        "Fake", options => { });

// Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("BuyerPolicy", policy =>
        policy.RequireRole(Roles.Buyer));

    options.AddPolicy("ApproverPolicy", policy =>
        policy.RequireRole(Roles.Approver));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Global exception handling
app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
