using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Authorization.Models
{
    public class CustomClaimTypes
    {
        public const string Permission = "Core/permission";
    }

    public static class Users
    {
        public const string View = "users.view";
        public const string Admin = "users.admin";
    }

    public static class Siteadmins
    {
        public const string All = "siteadmins.all";
    }
}
