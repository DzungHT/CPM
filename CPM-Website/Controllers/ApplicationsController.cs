using CPM_Website.Models;
using CPM_Website.Models.Common;
using CybertronFramework;
using CybertronFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CPM_Website.Controllers
{
    public class ApplicationsController : Controller
    {
        List<Application> lst = new List<Application>()
            {
                new Application() {ApplicationID = 1123, Code="CPM", Name="Cybertron Policies Management" },
                new Application() {ApplicationID = 223, Code="CPM 2", Name="Cybertron Policies Management" },
                new Application() {ApplicationID = 331, Code="CPM 3", Name="Cybertron Policies Management" }
            };

        // GET: Applications
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SearchProcess(ApplicationsViewModel formData)
        {
            List<Application> data = lst.Where(x => x.Code == formData.Code).ToList();
            DataTableResponse dataTableResponse = new DataTableResponse();
            dataTableResponse.data = data;
            dataTableResponse.recordsTotal = lst.Count;
            dataTableResponse.recordsFiltered = data.Count;
            dataTableResponse.error = null;
            dataTableResponse.draw = formData.DataTable.draw;
            return Json(dataTableResponse, JsonRequestBehavior.AllowGet);
        }
    }
}