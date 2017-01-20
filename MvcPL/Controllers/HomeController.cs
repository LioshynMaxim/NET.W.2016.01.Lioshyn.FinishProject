using System.Web.Mvc;
using System.Web.Security;
using BLL.Interfacies.Services;
using MvcPL.Models;
using MvcPL.Providers;

namespace MvcPL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Home
        [ActionName("Index")]
        public ActionResult Index()
        {
            return View(_userService.GetAllUser());
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var provider = (CustomMembershipProvider)Membership.Provider;

                if (provider.GetUser(userModel.Login, false) != null)
                {
                    ModelState.AddModelError("", "Login already exist");
                    return View(userModel);
                }

                var membershipUser = provider.CreateUser(userModel);

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(userModel.Login, false);
                    return RedirectToAction("Index");
                }
               
            }
            else
            {
                ModelState.AddModelError("", "Error while registration");
            }

            return View(userModel);
        }

        public ActionResult _Mail()
        {
            return PartialView();
        }



    }
}