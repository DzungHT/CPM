using CPM_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CPM_Website.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<MenuViewModel> lstMenu = new List<MenuViewModel>();
            lstMenu.Add(new MenuViewModel() { Name = "Trang chủ", Action="index", Controller = "home", MenuCss = "fa fa-home" });
            lstMenu.Add(new MenuViewModel() { Name = "Danh mục ứng dụng", Action="index", Controller = "applications", MenuCss = "fa fa-window-restore" });


            Session["lstMenu"] = lstMenu;
            return View();
        }
    }
}