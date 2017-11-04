using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMP_Servive.Models;
using CMP_Servive.Repository.Entities;
using CMP_Servive.Helper;

namespace CMP_Servive.Providers.Authentication
{
    public class ServiceToken : IServiceToken
    {
        private string AUTHORIZED_GRANT_TYPE = "password,authorization_code,refresh_token,implicit";
        private int ACCESS_TOKEN_VALIDITY = 100;
        private int REFRESS_TOKEN_VALIDITY = 1000;
        private string RESOURCE_ID = "rest_api";
        private string SCOPE = "trust,read,write";
        private string ROLE_ADMINISTRATOR = "ROLE_ADMINISTRATOR";

        dbContext db = new dbContext();

        public TokenUserIdentity crateUser(TokenUserIdentity obj)
        {
            string clientSecret = CommonUtil.RandomString(32).ToLower();
            obj.clientSecret = clientSecret;
            // create user
            OAuthDetail oauthDetail = new OAuthDetail();
            oauthDetail.UserName = obj.userName;
            oauthDetail.ClientId = obj.clientId;
            oauthDetail.IpAccess = obj.ipAccess;
            oauthDetail.Password = obj.passWord.ToMD5();
            db.OAuthDetails.Add(oauthDetail);
            db.SaveChanges();

            OAuthClientDetail oauthClientDetail = new OAuthClientDetail();
            oauthClientDetail.AccessTokenValidity = ACCESS_TOKEN_VALIDITY;
            oauthClientDetail.Authorities = obj.listRole;
            oauthClientDetail.GrantTypes = AUTHORIZED_GRANT_TYPE;
            oauthClientDetail.ClientId = obj.clientId;
            oauthClientDetail.ClientSecret = obj.clientSecret;
            oauthClientDetail.RefreshTokenValidity = REFRESS_TOKEN_VALIDITY;
            oauthClientDetail.ResourceIds = RESOURCE_ID;
            oauthClientDetail.Scope = SCOPE;
            db.OAuthClientDetails.Add(oauthClientDetail);
            db.SaveChanges();

            return obj;
        }

        public TokenUserIdentity login(TokenUserIdentity obj)
        {
            var result = from od in db.OAuthDetails
                         join ocd in db.OAuthClientDetails on od.ClientId equals ocd.ClientId
                         where ocd.ClientId == obj.clientId && od.UserName == obj.userName && od.Password == obj.passWord && ocd.ClientSecret == obj.clientSecret && ocd.GrantTypes.Contains(obj.grantType)
                         select new
                         {
                             ClientId = od.ClientId
                         };
            if(result != null)
            {
                return obj;
            } else
            {
                return null;
            }
        }

        public TokenInfo getToken(TokenUserIdentity obj)
        {
            throw new NotImplementedException();
        }

        public bool Kill(string tokenId)
        {
            throw new NotImplementedException();
        }

        public TokenInfo refreshToken(TokenUserIdentity obj)
        {
            throw new NotImplementedException();
        }

        public bool validateToken(string tokenId)
        {
            using (db)
            {
                OAuthAccessToken o = db.OAuthAccessTokens.FirstOrDefault(x => x.TokenId == tokenId);
                return o != null;
            }
        }
    }
}