using CPM_Website.CybertronFramework.Common;
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
        private const string API_LOGIN = "/v1/api/Users/login";

        #region HttpGet
        // GET: Account
        [HttpGet]
        public ActionResult Login(string ReturnUrl)
        {
            Session["ReturnUrl"] = ReturnUrl ?? "/";
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
        public async Task<ActionResult> Login(LoginViewModel formData)
        {
            IApiClient client = ApiClient.Instance;

            string s = await client.PostApiAsync<string, object>(API_LOGIN, new { UserName = formData.Username, Password = formData.Password });
            if (s != "")
            {
                FormsAuthentication.SetAuthCookie(s, formData.RememberMe);
            }
            string ReturnUrl = Session["ReturnUrl"].ToString();
            Session.Remove("ReturnUrl");

            List<MenuViewModel> lstMenu = new List<MenuViewModel>();
            lstMenu.Add(new MenuViewModel() { Name = "Trang chủ", Action = "index", Controller = "home", MenuCss = "fa fa-home" });
            lstMenu.Add(new MenuViewModel() { Name = "Danh mục ứng dụng", Action = "index", Controller = "applications", MenuCss = "fa fa-window-restore" });


            Session["lstMenu"] = lstMenu;
            return Redirect(ReturnUrl);
        }
        #endregion
    }
}