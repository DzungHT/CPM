using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPM_Website.Models.Common
{
    public static class Permission
    {
        public static bool HasPermission(string role)
        {
            if (HttpContext.Current.User.IsInRole(role))
            {
                return true;
            }
            return false;
        }
    }
}