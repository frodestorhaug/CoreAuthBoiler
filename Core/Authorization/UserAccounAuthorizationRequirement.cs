using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace datahound.Authorization
{
    public class UserAccountAuthorizationRequirement : IAuthorizationRequirement
    {
        public UserAccountAuthorizationRequirement(string role)
        {
            this.Role = role;
        }


        public string Role { get; private set; }
    }

   /*public class ViewUserAuthorizationHandler : AuthorizationHandler<UserAccountAuthorizationRequirement, string>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserAccountAuthorizationRequirement requirement, string targetUserId)
        {
            if (context.User == null || requirement.OperationName != AccountManagementOperations.ReadOperationName)
                return Task.CompletedTask;

            if (context.User.HasClaim(CustomClaimTypes.Permission, ApplicationPermissions.ViewUsers) || GetIsSameUser(context.User, targetUserId))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }


        private bool GetIsSameUser(ClaimsPrincipal user, string targetUserId)
        {
            if (string.IsNullOrWhiteSpace(targetUserId))
                return false;

            return Utilities.GetUserId(user) == targetUserId;
        }
    }*/
    
}