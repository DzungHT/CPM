﻿using CPM_Website.CybertronFramework.Common;
using CPM_Website.Models;
using CPM_Website.Models.Common;
using CybertronFramework;
using CybertronFramework.Libraries;
using CybertronFramework.Models;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CPM_Website.Controllers
{
    public class ApplicationsController : Controller
    {
        // GET: Applications
        [CybertronAuthorize(Roles = RoleCodes.Applications.INDEX)]
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> SearchProcess(ApplicationsViewModel formData)
        {
            ApiClient client = ApiClient.Instance;
            DataTableResponse dataTableResponse = new DataTableResponse();
            try
            {
                var apiResult = await client.PostApiAsync<JsonResultObject<List<Application>>, object>(Resources.URLResources.SEARCH_APPLICATION, 
                    new { Code = StringUtil.NVL(formData.Code), Name = StringUtil.NVL(formData.Name)});
                if (apiResult != null && apiResult.IsSuccess)
                {
                    List<Application> data = apiResult.Data;
                    dataTableResponse.data = data;
                    dataTableResponse.recordsTotal = data.Count;
                    dataTableResponse.recordsFiltered = data.Count;
                    dataTableResponse.error = null;
                    dataTableResponse.draw = formData.DataTable.draw;
                }

            } catch (Exception ex)
            {

            }
            return Json(dataTableResponse, JsonRequestBehavior.AllowGet);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Save(Application app)
        {
            ApiClient client = ApiClient.Instance;
            try
            {
                if (Permission.HasPermission(RoleCodes.Applications.SEARCH))
                {
                    var apiResult = await client.PostApiAsync<JsonResultObject<Application>, Application>(Resources.URLResources.SAVE_APPLICATION, app);
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

        [HttpPost]
        public async Task<JsonResult> PrepareUpdate(int id)
        {
            ApiClient client = ApiClient.Instance;
            try
            {
                var apiResult = await client.GetApiAsync<JsonResultObject<Application>>(Resources.URLResources.GET_APPLICATION + id);
                return Json(apiResult.Data);
            }
            catch (Exception ex)
            {

            }
            return Json(null);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            ApiClient client = ApiClient.Instance;
            try
            {
                if (Permission.HasPermission(RoleCodes.Applications.SEARCH))
                {
                    var apiResult = await client.PostApiAsync<JsonResultObject<String>, object>(Resources.URLResources.DELETE_APPLICATION + id,
                    new { });
                    ViewBag.Status = "1";
                } else
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
    }
}