using CPM_Website.CybertronFramework.Common;
using CPM_Website.Models;
using CPM_Website.Respositories;
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

            //string s = await client.PostApiAsync<string, object>(API_LOGIN, new { UserName = formData.Username, Password = formData.Password });
            if (DataFactory.Users.Any(x => x.LoginName.Equals(formData.Username) && x.Password.Equals(formData.Password)))
            {
                // Lấy danh sách quyền
                string roles = string.Join(",", DataFactory.Users.FirstOrDefault(x => x.LoginName.Equals(formData.Username) && x.Password.Equals(formData.Password)).Roles);

                var authTicket = new FormsAuthenticationTicket(1, formData.Username, DateTime.Now, DateTime.Now.AddMinutes(20), formData.RememberMe, roles);

                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                FormsAuthentication.SetAuthCookie(encryptedTicket, formData.RememberMe);


                // Lấy danh sách menu
                List<Menu> lstMenu = new List<Menu>();
                lstMenu.Add(new Menu() { Name = "Trang chủ", Action = "index", Controller = "home", FontIcon = "fa fa-home" });
                lstMenu.Add(new Menu() { Name = "Danh mục ứng dụng", Action = "index", Controller = "applications", FontIcon = "fa fa-window-restore" });
                Session["lstMenu"] = lstMenu;


                string ReturnUrl = Session["ReturnUrl"].ToString();
                return Redirect(ReturnUrl);
            }
            else
            {
                return RedirectToAction("login");
            }
        }
        #endregion
    }
}