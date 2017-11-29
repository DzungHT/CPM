using CMP_Servive.Business;
using CMP_Servive.Models.DTO;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CMP_Servive.Providers.Authentication
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        private string application { get; set; }
        private string roles { get; set; }

        /// <summary>
        /// Public default Constructor
        /// </summary>
        public BasicAuthenticationAttribute()
        {
            roles = "";
        }

        private readonly bool isActive = true;

        /// <summary>
        /// parameter isActive explicitly enables/disables this filetr.
        /// </summary>
        /// <param name="isActive"></param>
        public BasicAuthenticationAttribute(bool _isActive, string _role)
        {
            isActive = _isActive;
            roles = _role;
        }

        /// <summary>
        /// Checks basic authentication request
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext); // Should this be here?
            OutPutDTO outPut = new OutPutDTO();
            
            var owinContext = HttpContext.Current.GetOwinContext();
            var authenticated = owinContext.Authentication.User.Identity.IsAuthenticated;
            var request = HttpContext.Current.Request;
            var roleAccess = roles.Equals("") ? true : owinContext.Authentication.User.IsInRole(roles);
            
            if (!authenticated)
            {
                // Challenge user for crednetials
                if (!request.IsAuthenticated)
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
            }
            else
            {
                if (!roleAccess)
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                }
                return;
            }
        }
    }
}