using CMP_Servive.Helper;
using CMP_Servive.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using static CMP_Servive.Repository.DTO.UserLoginDTO;

namespace CMP_Servive.Business
{
    public class UserBusiness : BaseBusiness<dbContext>
    {
        public UserLoginOutput Login(UserLoginInput userInput)
        {
            UserLoginOutput result = new UserLoginOutput();
            // check user
            
            return result;
        }

        public User RestartPassword(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
            {
                string defaultPass = "123456".Encrypt(Constants.ENCRYPT_KEY);
                user.Password = defaultPass;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return user;
            }
            else
            {
                return null;
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