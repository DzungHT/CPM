using CMP_Servive.Models;
using CMP_Servive.Providers.Authentication;
using CMP_Servive.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CMP_Servive.Controllers
{
    [RoutePrefix("v1/api/Tokens")]
    public class TokensController : ApiController
    {
        ServiceToken serviceToken = new ServiceToken();
        dbContext db = new dbContext();

        [Route("createUser")]
        [HttpPost]
        public HttpResponseMessage createUser(TokenUserIdentity obj)
        {
            OAuthDetail oauthDetail0 = db.OAuthDetails.FirstOrDefault(x => x.UserName.Equals(obj.userName));
            if (oauthDetail0 != null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotAcceptable)
                {
                    Content = new StringContent("UserName is exist")
                };
            }
            OAuthDetail oauthDetail1 = db.OAuthDetails.FirstOrDefault(x => x.ClientId.Equals(obj.clientId));
            if (oauthDetail0 != null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotAcceptable)
                {
                    Content = new StringContent("ClientId is exist")
                };
            }
            TokenUserIdentity result = serviceToken.crateUser(obj);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("" + result, System.Text.Encoding.UTF8, "application/json")
            };
        }
    }
}
