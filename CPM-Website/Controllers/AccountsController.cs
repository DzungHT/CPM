using CPM_Website.CybertronFramework.Common;
using CPM_Website.Models;
using CPM_Website.Models.Common;
using CPM_Website.Models.ViewModels;
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

        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> SearchProcess(UserViewModel formData)
        {
            ApiClient client = ApiClient.Instance;
            DataTableResponse<UserViewModel> dataTableResponse = new DataTableResponse<UserViewModel>();
            try
            {
                var apiResult = await client.PostApiAsync<JsonResultObject<DataTableResponse<UserViewModel>>, object>(URLResources.SEARCH_USER + "?offset=" + formData.DataTable.start.ToString() + "&recordPerPage=" + formData.DataTable.length.ToString(),
                    new { LoginName = formData.LoginName, FullName = formData.FullName, Email = formData.Email, PhoneNumber = formData.PhoneNumber, Status = formData.Status });
                if (apiResult != null && apiResult.IsSuccess)
                {
                    dataTableResponse = apiResult.Data;
                }

            }
            catch (Exception ex)
            {

            }
            return Json(dataTableResponse, JsonRequestBehavior.AllowGet);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Save(User obj)
        {
            ApiClient client = ApiClient.Instance;
            try
            {
                if (Permission.HasPermission(RoleCodes.Applications.SEARCH))
                {
                    var apiResult = await client.PostApiAsync<JsonResultObject<User>, User>(URLResources.SAVE_USER, obj);
                    if(apiResult.Status == "05")
                    {
                        ViewBag.Status = "0";
                    } else
                    {
                        ViewBag.Status = "1";
                    }
                    
                }
                else
                {
                    ViewBag.Status = "0";
                }

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("401"))
                {
                    ViewBag.Status = "-2";
                }
            }
            return PartialView(Constants.VIEW.SAVE_RESULT);
        }

        [HttpPost]
        public async Task<JsonResult> PrepareUpdate(int id)
        {
            ApiClient client = ApiClient.Instance;
            try
            {
                var apiResult = await client.GetApiAsync<JsonResultObject<User>>(URLResources.GET_USER + id);
                return Json(apiResult.Data);
            }
            catch (Exception ex)
            {

            }
            return Json(null);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> LockUnlock(int id)
        {
            ApiClient client = ApiClient.Instance;
            try
            {
                if (Permission.HasPermission(RoleCodes.Applications.SEARCH))
                {
                    var apiResult = await client.PostApiAsync<JsonResultObject<User>, object>(URLResources.LOCK_UNLOCK_USER + id,
                    new { });
                    ViewBag.Status = "1";
                }
                else
                {
                    ViewBag.Status = "0";
                }

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("401"))
                {
                    ViewBag.Status = "-2";
                }
            }
            return PartialView(Constants.VIEW.SAVE_RESULT);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> RestartPassword(int id)
        {
            ApiClient client = ApiClient.Instance;
            try
            {
                if (Permission.HasPermission(RoleCodes.Applications.SEARCH))
                {
                    var apiResult = await client.PostApiAsync<JsonResultObject<User>, object>(URLResources.RESTART_USER + id,null);
                    ViewBag.Status = "1";
                }
                else
                {
                    ViewBag.Status = "0";
                }

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("401"))
                {
                    ViewBag.Status = "-2";
                }
            }
            return PartialView(Constants.VIEW.SAVE_RESULT);
        }

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
                    string roleStr = string.Join(Constants.ROLE_STRING_SEPERATE,  RoleCodes.Applications.INDEX);

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