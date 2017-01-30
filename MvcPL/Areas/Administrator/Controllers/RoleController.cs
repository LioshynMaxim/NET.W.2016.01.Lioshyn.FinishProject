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
            if (Request.IsAjaxRequest()) return PartialView(_roleService.GetById(id).ToRoleModel());
            return View(_roleService.GetById(id).ToRoleModel());
        }

        #region Create

        public ActionResult Create()
        {
            if (Request.IsAjaxRequest()) return PartialView();
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
                if (Request.IsAjaxRequest()) return PartialView();
                return View();
            }
        }

        #endregion

        #region edit

        public ActionResult Edit(int id)
        {
            if (Request.IsAjaxRequest()) return PartialView(_roleService.GetById(id).ToRoleModel());
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
                if (Request.IsAjaxRequest()) return PartialView();
                return View();
            }
        } 

        #endregion
        
        #region Delete

        public ActionResult Delete(int id)
        {
            return View(_roleService.GetById(id).ToRoleModel());
        }

        [HttpPost]
        public ActionResult Delete(RoleModel model)
        {
            try
            {
                _roleService.Delete(_roleService.GetById(model.Id));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View(_roleService.GetById(model.Id).ToRoleModel());
            }
        }

        #endregion


    }
}
