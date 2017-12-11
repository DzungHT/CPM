using CPM_Website.CybertronFramework.Common;
using CPM_Website.Models;
using CybertronFramework;
using CybertronFramework.Libraries;
using CybertronFramework.Models;
using Resources;
using System;
using System.Collections.Generic;
using System.Net;
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
            FormsAuthentication.SignOut();
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
        public async Task<ActionResult> Login(AccountViewModel formData)
        {
            getAccessToken(formData);
            ApiClient client = ApiClient.Instance;
            try
            {
                var apiResult = await client.PostApiAsync<JsonResultObject<User>, object>(URLResources.LOGIN_API, new { UserName = formData.Username, Password = formData.Password, ApplicationCode = "CPM" });
                if (apiResult != null && apiResult.IsSuccess)
                {
                    // Lấy danh sách quyền
                    string roleStr = string.Join(Constants.ROLE_STRING_SEPERATE, apiResult.Data.Roles);

                    var authTicket = new FormsAuthenticationTicket(1, formData.Username, DateTime.Now, DateTime.Now.AddMinutes(20), formData.RememberMe, roleStr);

                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    FormsAuthentication.SetAuthCookie(encryptedTicket, formData.RememberMe);

                    //
                    Session["USER"] = apiResult.Data;
                    // Lấy danh sách menu
                    List<Menu> lstMenu = new List<Menu>();
                    var getListMenu = await client.GetApiAsync<JsonResultObject<List<Menu>>>(URLResources.GET_MENU + "?userId=" + apiResult.Data.UserID);
                    Session["lstMenu"] = getListMenu.Data;

                    string ReturnUrl = (string)Session["ReturnUrl"];
                    return Redirect(ReturnUrl);
                }
                ModelState.AddModelError(string.Empty, "Đăng nhập không thành công!");
                return PartialView("login");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Đăng nhập không thành công!");
                return PartialView("login");
            }
        }
        #endregion

        private void getAccessToken(AccountViewModel formData)
        {
            ApiClient client = ApiClient.Instance;
            AuthenticationLogin model = new AuthenticationLogin();
            model.client_id = ApplicationResources.AppNameSumary;
            model.client_secret = formData.Password;
            model.grant_type = "password";
            model.username = formData.Username;
            model.password = formData.Password;
            var result = client.GetAccessToken(model);
        }
    }
}