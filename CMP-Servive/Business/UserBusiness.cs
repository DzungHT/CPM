using CMP_Servive.Models.Common;
using CMP_Servive.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMP_Servive.Business
{
    public class UserBusiness :IBusinessBase
    {
        dbContext db = new dbContext();

        public bool login(string userName, string password)
        {
            using (db)
            {
                return db.Users.Any(user => user.LoginName.Equals(userName, StringComparison.OrdinalIgnoreCase)
                                         && user.Password.Equals(password));
            }
        }
    }
}