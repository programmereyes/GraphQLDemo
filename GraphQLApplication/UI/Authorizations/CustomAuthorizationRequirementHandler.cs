using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace UI.Authorizations
{
    public class CustomAuthorizationRequirementHandler : AuthorizationHandler<CustomAuthorizationRequirement>
    { 
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomAuthorizationRequirement requirement)
        {

            if (context.User.Identity.IsAuthenticated && context.User.Claims.Any(x => x.Value == requirement.ClaimValue && x.Type == requirement.ClaimName))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
