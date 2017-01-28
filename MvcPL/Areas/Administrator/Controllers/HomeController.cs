using System.Web.Mvc;

namespace MvcPL.Areas.Administrator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}