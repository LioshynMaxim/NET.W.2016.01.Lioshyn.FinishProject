using System;
using System.Linq;
using System.Web.Mvc;
using BLL.Interfacies.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;
using NLog;

namespace MvcPL.Areas.Administrator.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        private Logger logger = LogManager.GetCurrentClassLogger();

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }


        public ActionResult Index()
        {
            return View(_roleService.GetAll().Select(s => s.ToRoleModel()));
        }

        public ActionResult Details(int id)
        {
            return View(_roleService.GetById(id).ToRoleModel());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RoleModel roleModel)
        {
            try
            {
                _roleService.Create(roleModel.ToBllRole());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(_roleService.GetById(id).ToRoleModel());
        }

        [HttpPost]
        public ActionResult Edit(RoleModel roleModel)
        {
            try
            {
                _roleService.Update(roleModel.ToBllRole());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _roleService.Delete(_roleService.GetById(id));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View();
            }
        }

        public ActionResult TestAddActionResult()
        {
            _roleService.AddUserToRole(1, 1);
            _roleService.AddUserToRole(1, 2);
            return RedirectToAction("Index");
        }

        public ActionResult TestDeleteActionResult()
        {
            _roleService.DeleteUserToRole(1, 1);
            return RedirectToAction("Index");
        }
    }
}
