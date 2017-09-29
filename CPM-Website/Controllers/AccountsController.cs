using CPM_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Logout()
        {
            return RedirectToAction("Login", "Accounts");
        }
        #endregion



        #region HttpPost
        [HttpPost]
        public ActionResult Login(LoginViewModel formData)
        {
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}