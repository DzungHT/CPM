using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CPM_Website.Models;

namespace CPM_Website.Controllers
{
    public class TestController : Controller
    {

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
    }
}
