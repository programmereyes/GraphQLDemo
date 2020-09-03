using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace UI.Authentications
{
    public class CustomAuthenticationHandler : AuthenticationHandler<CustomAuthenticationSchemeOptions>
    {
        public CustomAuthenticationHandler(
           IOptionsMonitor<CustomAuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {

        }
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var claims = new List<Claim>() { 
                new Claim(ClaimTypes.Name, "Aditya"),
                new Claim(ClaimTypes.Email, "custom@customdomain.com"),
                new Claim("customclaim","customvalue") };
            var claimIdentity = new ClaimsIdentity(claims, "customauth",ClaimTypes.Name,null);
            var claimPrinciple = new ClaimsPrincipal(claimIdentity);
            var authenticationTicket = new AuthenticationTicket(claimPrinciple, "customauth");
            return Task.FromResult(AuthenticateResult.Success(authenticationTicket));
        }
    }
}
