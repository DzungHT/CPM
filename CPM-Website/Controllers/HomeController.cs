using CPM_Website.CybertronFramework.Common;
using CPM_Website.Models;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CPM_Website.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize(Roles = "")]
        public ActionResult Index()
        {
            return View();
        }
    }
}