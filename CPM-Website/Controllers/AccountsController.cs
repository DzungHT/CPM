using CPM_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
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
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Accounts");
        }
        #endregion



        #region HttpPost
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel formData)
        {
            
            //FormsAuthentication.SetAuthCookie(acc.Username, formData.RememberMe);
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}