using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using PRService.Domain.Constants;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace PRService.API.Auth
{
    public sealed class FakeAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public FakeAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock) { }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // Later it will be replaced by JWT
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "test-user"),
                new Claim(ClaimTypes.Role, Roles.Buyer),
                new Claim(ClaimTypes.Role, Roles.Approver)
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }

    }
}
