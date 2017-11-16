using CPM_Website.Models;
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

        [HttpPost]
        public JsonResult Create(Application app)
        {
            return Json(new JsonResultObject());
        }
    }
}