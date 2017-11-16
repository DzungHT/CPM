using CMP_Servive.Business;
using CMP_Servive.Helper;
using CMP_Servive.Models.Entities;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
namespace CMP_Servive.Providers
{
    public class ApplicationRefreshTokenProvider : IAuthenticationTokenProvider
    {

        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var clientid = context.Ticket.Properties.Dictionary["as:client_id"];

            if (string.IsNullOrEmpty(clientid))
            {
                return;
            }

            var refreshTokenId = Guid.NewGuid().ToString("n");

            CommonBusiness commonBu = new CommonBusiness();
            var token = new OAuthRefreshToken()
            {
                TokenId = refreshTokenId.GetHash(),
                Authentication = context.SerializeTicket()
            };
            commonBu.Save(token);
            commonBu.getDbContext().SaveChanges();
            context.SetToken(refreshTokenId);
        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {

            string hashedTokenId = context.Token.GetHash();

            CommonBusiness commonBu = new CommonBusiness();
            OAuthRefreshToken refreshToken = commonBu.FindByProperty<OAuthRefreshToken>("TokenId", hashedTokenId, "")[0];

            if (refreshToken != null)
            {
                //Get protectedTicket from refreshToken class
                context.DeserializeTicket(refreshToken.Authentication);

                commonBu.getDbContext().OAuthRefreshTokens.Remove(refreshToken);
                commonBu.getDbContext().SaveChanges();
            }
        }

        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }
    }
}