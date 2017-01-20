using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interfacies.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;
using MvcPL.Providers;

namespace MvcPL.Areas.Administrator.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #region Index

        [ActionName("Index")]
        public ActionResult Index()
        {
            return View(_userService.GetAll().Select(s=>s.ToUserModel()));
        }
        
        #endregion
        
        #region Details

        [ActionName("Details")]
        public ActionResult Details(int idUser)
        {
            return View(_userService.GetById(idUser).ToUserModel());
        }

        #endregion
        
        #region Create

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserModel userModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Error while registration");
                }
                else
                {
                    var provider = (CustomMembershipProvider)Membership.Provider;

                    if (provider.GetUser(userModel.Login, false) != null)
                    {
                        ModelState.AddModelError("", "Login already exist");
                        return View(userModel);
                    }

                    var membershipUser = provider.CreateUser(userModel);

                    if (membershipUser == null) return RedirectToAction("Index");
                    FormsAuthentication.SetAuthCookie(userModel.Login, false);

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(userModel);
            }
        }

        #endregion

        #region Edit

        public ActionResult Edit(int idUser)
        {
            try
            {
                return View(_userService.GetById(idUser).ToUserModel());
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(int idUser, FormCollection collection)
        {
            try
            {
                _userService.Update(_userService.GetById(idUser));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region Delete

        public ActionResult Delete(int idUser)
        {
            return View(_userService.GetById(idUser).ToUserModel());
        }

        [HttpPost]
        public ActionResult Delete(int idUser, FormCollection collection)
        {
            try
            {
                _userService.Delete(_userService.GetById(idUser));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion


    }
}
