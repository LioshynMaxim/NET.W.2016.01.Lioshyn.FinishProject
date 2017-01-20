using System.Linq;
using System.Web.Mvc;
using BLL.Interfacies.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;

namespace MvcPL.Areas.Administrator.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }


        // GET: Home
        public ActionResult Index()
        {
            return View(_roleService.GetAll().Select(s => s.ToRoleModel()));
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View(_roleService.GetById(id).ToRoleModel());
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(RoleModel roleModel)
        {
            try
            {
                _roleService.Create(roleModel.ToBllRole());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_roleService.GetById(id).ToRoleModel());
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(RoleModel roleModel)
        {
            try
            {
                _roleService.Update(roleModel.ToBllRole());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _roleService.Delete(_roleService.GetById(id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult TestAddActionResult()
        {
            _roleService.AddRoleToUser(1, 1);
            _roleService.AddRoleToUser(1, 2);
            return RedirectToAction("Index");
        }

        public ActionResult TestDeleteActionResult()
        {
            _roleService.DeleteUserToRole(1, 1);
            return RedirectToAction("Index");
        }
    }
}
