using CPM_Website.CybertronFramework.Common;
using CPM_Website.Models;
using CybertronFramework;
using CybertronFramework.Libraries;
using Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        [CybertronAuthorize]
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
            ApiClient client = ApiClient.Instance;
            var apiResult = await client.PostApiAsync<JsonResultObject<User>, object>(URLResources.LOGIN_API, new { UserName = formData.Username, Password = formData.Password, ApplicationID = 1 });
            if (apiResult.IsSuccess)
            {
                // Lấy danh sách quyền
                string roleStr = string.Join(Constants.ROLE_STRING_SEPERATE, apiResult.Data.Roles);

                var authTicket = new FormsAuthenticationTicket(1, formData.Username, DateTime.Now, DateTime.Now.AddMinutes(20), formData.RememberMe, roleStr);

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