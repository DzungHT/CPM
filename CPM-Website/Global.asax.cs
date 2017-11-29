using CPM_Website.CybertronFramework.Common;
using CybertronFramework;
using CybertronFramework.Libraries;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace CPM_Website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ApiClient.BaseURI = URLResources.BASE_URI;
        }

        /// <summary>
        /// Sự kiện xảy ra khi xác thực đăng nhập trước khi thực hiện action.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void FormsAuthentication_OnAuthenticate(Object sender, FormsAuthenticationEventArgs e)
        {
            if (FormsAuthentication.CookiesSupported == true)
            {
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie != null)
                {
                    try
                    {
                        FormsAuthenticationTicket ticketCookie = FormsAuthentication.Decrypt(authCookie.Value);
                        FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(ticketCookie.Name);
                        string[] roles = authTicket.UserData.Split(new string[] { Constants.ROLE_STRING_SEPERATE }, StringSplitOptions.RemoveEmptyEntries);
                        e.User = new System.Security.Principal.GenericPrincipal(new FormsIdentity(authTicket), roles);
                    }
                    catch(Exception)
                    {

                    }
                }
            }
        }
    }
}
