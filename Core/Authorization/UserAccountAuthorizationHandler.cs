using System.Security.Claims;
using System.Threading.Tasks;
using AspNet.Security.OpenIdConnect.Primitives;
using Microsoft.AspNetCore.Authorization;

namespace Core.Authorization
{
    public class UserAccountAuthorizationHandler : AuthorizationHandler<UserAccountAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserAccountAuthorizationRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == OpenIdConnectConstants.Claims.Role )) {
                return Task.CompletedTask;
            }

            //var role = context.User.FindFirst(c=>c.Type == OpenIdConnectConstants.Claims.Role )
             return Task.CompletedTask;
        }
    }
}