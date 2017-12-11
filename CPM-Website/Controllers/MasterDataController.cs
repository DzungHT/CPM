using CPM_Website.Models;
using CybertronFramework.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CPM_Website.Controllers
{
    public class MasterDataController : Controller
    {
        [HttpGet]
        public async Task<JsonResult> getListApplication()
        {
            ApiClient client = ApiClient.Instance;
            try
            {
                var apiResult = await client.GetApiAsync<JsonResultObject<List<Application>>>(Resources.URLResources.GET_ALL_APPLICATION);
                if (apiResult != null && apiResult.IsSuccess)
                {
                    return Json(apiResult.Data);
                }

            }
            catch (Exception ex)
            {

            }
            return Json(null);
        }
    }
}