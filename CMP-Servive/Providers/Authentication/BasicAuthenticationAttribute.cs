using CMP_Servive.Business;
using CMP_Servive.Models.DTO;
using CMP_Servive.Providers.Authentication;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CMP_Servive.Authentication.Providers
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        /// <summary>
        /// Public default Constructor
        /// </summary>
        public BasicAuthenticationAttribute()
        {
        }

        private readonly bool isActive = true;

        /// <summary>
        /// parameter isActive explicitly enables/disables this filetr.
        /// </summary>
        /// <param name="isActive"></param>
        public BasicAuthenticationAttribute(bool _isActive)
        {
            isActive = _isActive;
        }

        /// <summary>
        /// Checks basic authentication request
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (!isActive) return;

            var identity = FetchAuthHeader(actionContext);
            if (identity == null)
            {
                ChallengeAuthRequest(actionContext);
                return;
            }

            UserBusiness userBusiness = new UserBusiness();
            UserLoginInput usip = new UserLoginInput();
            usip.UserName = identity.UserName;
            usip.Password = identity.Password;
            if (true)
            {
                ChallengeAuthRequest(actionContext);
                return;
            }
            else
            {
                var genericPrincipal = new GenericPrincipal(identity, null);
                Thread.CurrentPrincipal = genericPrincipal;
            }
        }

        /// <summary>
        /// Checks for autrhorization header in the request and parses it, creates user credentials and returns as BasicAuthenticationIdentity
        /// </summary>
        /// <param name="actionContext"></param>
        protected virtual BasicAuthenticationIdentity FetchAuthHeader(HttpActionContext actionContext)
        {
            string authHeaderValue = null;
            var authRequest = actionContext.Request.Headers.Authorization;
            if (authRequest != null && !String.IsNullOrEmpty(authRequest.Scheme) && authRequest.Scheme == "Basic")
                authHeaderValue = authRequest.Parameter;
            if (string.IsNullOrEmpty(authHeaderValue))
                return null;
            authHeaderValue = Encoding.UTF8.GetString(Convert.FromBase64String(authHeaderValue));
            var credentials = authHeaderValue.Split(':');
            return credentials.Length < 2 ? null : new BasicAuthenticationIdentity(credentials[0], credentials[1]);
        }

        /// <summary>
        /// Send the Authentication Challenge request
        /// </summary>
        /// <param name="filterContext"></param>
        private static void ChallengeAuthRequest(HttpActionContext filterContext)
        {
            var dnsHost = filterContext.Request.RequestUri.DnsSafeHost;
            filterContext.Response = filterContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            filterContext.Response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", dnsHost));
        }
    }
}