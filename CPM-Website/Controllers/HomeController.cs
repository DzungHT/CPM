using System.Web.Mvc;
using CybertronFramework;
using CPM_Website.Models;

namespace CPM_Website.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [CybertronAuthorize(Roles = RoleCodes.Home.INDEX)]
        public ActionResult Index()
        {
            //User user = (User)Session["USER"];
            //if (user != null) { 
            //    ViewBag.Fullname = user.FullName;
            //}
            return View();
        }
    }
}