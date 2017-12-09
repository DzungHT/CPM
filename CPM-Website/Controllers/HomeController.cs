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
            return View();
        }
    }
}