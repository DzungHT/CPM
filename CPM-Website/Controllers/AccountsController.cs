using CPM_Website.CybertronFramework.Common;
using CPM_Website.Models;
using CPM_Website.Respositories;
using CybertronFramework.Libraries;
using CybertronFramework.Models;
using Resources;
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
        public async Task<ActionResult> Login(AccountViewModel formData)
        {
            getAccessToken(formData);
            if (Session["TOKEN"] != null && !"".Equals((string)Session["TOKEN"]))
            {
                ApiClient client = new ApiClient(URLResources.BASE_URI, (string)Session["TOKEN"]);// (string)Session["TOKEN"]);
                var apiResult = await client.PostApiAsync<JsonResultObject<User>, object>(URLResources.LOGIN_API, new { UserName = formData.Username, Password = formData.Password, ApplicationCode = "CPM" });
                if (apiResult != null && apiResult.IsSuccess)
                {
                    // Lấy danh sách quyền
                    apiResult.Data.Roles = new string[] { "VIEW_HOME", "VIEW_APPLICATION" };
                    string roleStr = string.Join(Constants.ROLE_STRING_SEPERATE, apiResult.Data.Roles);

                    var authTicket = new FormsAuthenticationTicket(1, formData.Username, DateTime.Now, DateTime.Now.AddMinutes(20), formData.RememberMe, roleStr);

                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    FormsAuthentication.SetAuthCookie(encryptedTicket, formData.RememberMe);

                    // Lấy danh sách menu
                    List<Menu> lstMenu = new List<Menu>();
                    lstMenu.Add(new Menu() { Name = "Trang chủ", Action = "index", Controller = "home", FontIcon = "fa fa-home" });
                    lstMenu.Add(new Menu() { Name = "Danh mục ứng dụng", Action = "index", Controller = "applications", FontIcon = "fa fa-window-restore" });
                    Session["lstMenu"] = lstMenu;

                    string ReturnUrl = (string)Session["ReturnUrl"];
                    return Redirect(ReturnUrl);
                }
                return RedirectToAction("login");
            } else
            {
                return RedirectToAction("login");
            } 
        }
        #endregion

        private void getAccessToken(AccountViewModel formData)
        {
            ApiClient client = ApiClient.Instance;
            Session["TOKEN"] = null;
            AuthenticationLogin model = new AuthenticationLogin();
            model.client_id = ApplicationResources.AppNameSumary;
            model.client_secret = formData.Password;
            model.grant_type = "password";
            model.username = formData.Username;
            model.password = formData.Password;
            var result = client.GetAccessToken(model);
            Session["TOKEN"] = result.Result;
        }
    }
}