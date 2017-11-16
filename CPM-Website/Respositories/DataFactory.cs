using CPM_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPM_Website.Respositories
{
    public static class DataFactory
    {
        public static List<User> Users = new List<User>()
        {
            new User(){ UserID = 1, LoginName = "admin", Password = "admin", Roles = new Role[] { Roles[0] } }
        };

        public static List<Role> Roles = new List<Role>()
        {
            new Role(){ RoleID = 0, Code = "SYS_ADMIN" }
        };
    }
}