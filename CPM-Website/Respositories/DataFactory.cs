using CPM_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPM_Website.Respositories
{
    public static class DataFactory
    {
        public static List<User> Users
        {
            get
            {
                return 
                    new List<User>()
                    { new User()
                        {
                            UserID = 1,
                            LoginName = "admin",
                            Password = "GaKFQUS2Oo92F6byJQGbEg==",
                            Roles = new string[]
                            {
                                RoleCodes.Home.INDEX,
                                RoleCodes.Applications.INDEX,
                                RoleCodes.Applications.SEARCH
                            }
                        }
                    };
            }
        }
        public static List<Role> Roles = new List<Role>()
        {
            new Role(){ RoleID = 0, Code = "SYS_ADMIN" }
        };
    }
}