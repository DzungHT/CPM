using CPM_Website.Models;
using CybertronFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace CPM_Website.Controllers
{
    public class AccountsController : Controller
    {
        #region HttpGet
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return PartialView();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Logout()
        {
            //FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Accounts");
        }
        #endregion



        #region HttpPost
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel formData)
        {
            IApiClient client = new ApiClient("http://localhost:8880");

            string s = await client.PostApiAsync<string, object>("/v1/api/Users/login", new { UserName = "123", Password = "123" });
            //FormsAuthentication.SetAuthCookie(acc.Username, formData.RememberMe);
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}