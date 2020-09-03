using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Authorizations
{
    public class CustomAuthorizationRequirement: IAuthorizationRequirement
    {
        public string ClaimName { get; private set; }
        public string ClaimValue { get; private set; }

        public CustomAuthorizationRequirement(string claimName, string claimValue)
        {
            ClaimName = claimName;
            ClaimValue = claimValue;
        }
    }
}
