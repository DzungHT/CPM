using CMP_Servive.Helper;
using CMP_Servive.Models.DTO;
using CMP_Servive.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CMP_Servive.Business
{
    public class UserBusiness : BaseBusiness<dbContext>
    {

        public User RestartPassword(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
            {
                string defaultPass = "123456".EncryptPassword(Constants.ENCRYPT_KEY);
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

        public UserLoginOutput GetUserInformation(UserLoginInput userInput)
        {
            UserLoginOutput result = new UserLoginOutput();
            // check user
            db.Configuration.LazyLoadingEnabled = true;
            var user = db.Users.FirstOrDefault(x => x.LoginName == userInput.UserName && x.Password == userInput.Password);
            result.GetTransferData(user);

            result.Roles = db.Database.SqlQuery<string>("sp_GetUserPermission @UserID, @ApplicationCode", new SqlParameter("UserID", user.UserID), new SqlParameter("ApplicationCode", userInput.ApplicationCode)).ToList();
            return result;
        }

        public bool CheckLogin(UserLoginInput userInput)
        {
            bool isLoginSuccess = db.Users.Any(x => x.LoginName == userInput.UserName && x.Password == userInput.Password);
            return isLoginSuccess;
        }
    }
}