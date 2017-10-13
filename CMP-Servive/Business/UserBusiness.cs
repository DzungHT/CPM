using CMP_Servive.Models.Common;
using CMP_Servive.Models.Entities;
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
            using (db)
            {
                string pas = password.ToMD5();
                bool ckeckexit = db.Users.Any(user => user.LoginName.Equals(userName, StringComparison.OrdinalIgnoreCase));
                if (ckeckexit)
                {
                    return db.Users.Any(user => user.LoginName.Equals(userName, StringComparison.OrdinalIgnoreCase)
                                             && user.Password.Equals(pas));
                } else
                {
                    return false;
                }
            }
        }

        public bool save(User user)
        {
            using(db)
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
            return user.UserID > 0;
        }

        public bool update(User user)
        {
            using (db)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
            return user.UserID > 0;
        }

        public bool delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            } else
            {
                return false;
            }
        }

        public bool restartPassword(int id)
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

        public List<User> getList()
        {
            using (db)
            {
                return db.Users.ToList();
            }
        }

        public User getObject(int id)
        {
            using (db)
            {
                return db.Users.Find(id);
            }
        }

        public bool addRole(int userId, List<int> lstRoleId)
        {
            db.UserRoles.AddRange(
                    lstRoleId.Select(x => new UserRole { UserID = userId, RoleID = x, IsActive = 1 })
                );
            db.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}