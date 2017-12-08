using CMP_Servive.Helper;
using CMP_Servive.Models.DTO;
using CMP_Servive.Models.Entities;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CMP_Servive.Business
{
    public class AuthorizationBusiness : BaseBusiness<dbContext>
    {
        /// <summary>
        /// Lấy thông tin người dùng đơn giản
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public UserLoginOutput getUser(OAuthGrantResourceOwnerCredentialsContext context)
        {
            UserLoginOutput result = new UserLoginOutput();
            db.Configuration.LazyLoadingEnabled = true;
            string loginName = context.UserName.Trim();
            string pass = context.Password.Encrypt(Constants.ENCRYPT_KEY);
            string appCode = context.ClientId.Trim();
            var user = db.Users.FirstOrDefault(x => x.LoginName.Equals(loginName) && x.Password.Equals(pass));
            if (user == null)
            {
                return null;
            }
            result.GetTransferData(user);
            result.Roles = db.Database.SqlQuery<string>("sp_GetUserPermission @UserID, @ApplicationCode", new SqlParameter("UserID", user.UserID), new SqlParameter("ApplicationCode", appCode)).ToList();
            //var listRole = from ur in db.UserRoles
            //               join rp in db.Rol on ur.UserID =
            return result;
        }

    }
}