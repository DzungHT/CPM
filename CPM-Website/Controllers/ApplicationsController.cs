using CPM_Website.Models;
using CybertronFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CPM_Website.Controllers
{
    public class ApplicationsController : Controller
    {
        // GET: Applications
        [Authorize(Roles = RoleCodes.Applications.INDEX)]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = RoleCodes.Applications.INDEX)]
        public ActionResult IndexView()
        {
            return PartialView();
        }

        [Authorize(Roles = RoleCodes.Applications.SEARCH)]
        public ActionResult SearchView()
        {
            return PartialView();
        }

        
        public JsonResult SearchProcess()
        {
            List<Application> lst = new List<Application>()
            {
                new Application() {ApplicationID = 1123, Code="CPM", Name="Cybertron Policies Management" },
                new Application() {ApplicationID = 223, Code="CPM 2", Name="Cybertron Policies Management" },
                new Application() {ApplicationID = 331, Code="CPM 3", Name="Cybertron Policies Management" }
            };
            DataTableResponse dataTableResponse = new DataTableResponse();
            dataTableResponse.data = lst;
            dataTableResponse.recordsTotal = 100;
            dataTableResponse.recordsFiltered = 1;
            dataTableResponse.error = null;
            return Json(dataTableResponse, JsonRequestBehavior.AllowGet);
        }
    }
}