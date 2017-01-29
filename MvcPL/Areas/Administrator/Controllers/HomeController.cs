using System;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interfacies.Services;

namespace MvcPL.Areas.Administrator.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Settings()
        {
            string login = HttpContext.User.Identity.Name;
            int id = _userService.GetUserByLogin(login).Id;
            return RedirectToAction("UserInformation", new { area = "Administrator", controller = "User", idUser = id });
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home",new {area ="", controller = "Home"});
        }
    }
}