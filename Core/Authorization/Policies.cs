namespace datahound.Authorization
{
    public class Policies
    {
        ///<summary>Policy to allow user.</summary>
        public const string User = "User access";
        ///<summary>Policy to allow admin.</summary>
        public const string Admin = "Admin access";

        ///<summary>Policy to allow siteadmin.</summary>
        public const string SiteAdmin = "Siteadmin access";
    }

    public static class AccountManagementOperations
    {
        public const string UserAccountAccessOperationName = "UserAccount";
        public const string AdminAccessOperationName = "AdminAccess";
        public const string SiteAdminAccessOperationName = "SiteAdminAccess";

        public static UserAccountAuthorizationRequirement UserAccountAccess = new UserAccountAuthorizationRequirement(UserAccountAccessOperationName);
        public static UserAccountAuthorizationRequirement AdminAccess = new UserAccountAuthorizationRequirement(AdminAccessOperationName);
        public static UserAccountAuthorizationRequirement SiteAdminAccess = new UserAccountAuthorizationRequirement(SiteAdminAccessOperationName);
    }
}