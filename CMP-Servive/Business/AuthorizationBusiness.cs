using CMP_Servive.Helper;
using CMP_Servive.Repository.Entities;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
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
        public OAuthDetail getUser(OAuthGrantResourceOwnerCredentialsContext context)
        {
            OAuthDetail result = new OAuthDetail();
            db.Configuration.LazyLoadingEnabled = true;
            string pass = context.Password.Encrypt(Constants.ENCRYPT_KEY);
            result = db.OAuthDetails.FirstOrDefault(
                x =>  x.UserName.Contains(context.UserName)
                  && x.Password.Contains(pass)
                  && x.ClientId.Contains(context.ClientId));
            return result;
        }

    }
}