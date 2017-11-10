using CMP_Servive.Helper;
using CMP_Servive.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CMP_Servive.Business
{
    public class UserBusiness : BaseBusiness<dbContext>
    {
        public bool Login(string userName, string password)
        {
            string pas = password.ToMD5();
            bool ckeckexit = db.Users.Any(user => user.LoginName.Equals(userName, StringComparison.OrdinalIgnoreCase));
            if (ckeckexit)
            {
                return db.Users.Any(user => user.LoginName.Equals(userName, StringComparison.OrdinalIgnoreCase)
                                         && user.Password.Equals(pas));
            }
            else
            {
                return false;
            }
        }

        public bool RestartPassword(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
            {
                user.Password = "zgv9FQWbaNZ2iIhNej0+jA==";
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddRole(int userId, List<int> lstRoleId)
        {
            db.UserRoles.AddRange(
                    lstRoleId.Select(x => new UserRole { UserID = userId, RoleID = x, IsActive = 1 })
                );
            db.SaveChanges();
            return true;
        }
    }
}