using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace EComm.API.Auth;

public class MyCustomAuthHandler 
    : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public MyCustomAuthHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder)
        : base(options, logger, encoder) { }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.ContainsKey("X-PSK"))
            return Task.FromResult(AuthenticateResult.Fail("Header Not Found"));

        var psk = Request.Headers["X-PSK"].ToString();
        if (psk != "abc123")
            return Task.FromResult(AuthenticateResult.Fail("Invalid PSK"));

        var principal = new ClaimsPrincipal(
            new ClaimsIdentity([
                new Claim(ClaimTypes.Name, "SomeUser"),
                new Claim(ClaimTypes.Role, "Admin")
              ], nameof(MyCustomAuthHandler)));

        var ticket = new AuthenticationTicket(principal, this.Scheme.Name);
        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}
