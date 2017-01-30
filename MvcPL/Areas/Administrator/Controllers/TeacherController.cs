using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.Interfacies.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;

namespace MvcPL.Areas.Administrator.Controllers
{
    public class TeacherController : Controller
    {

        private readonly IFullTeacherService _fullTeacherService;
        private readonly ITeacherService _teacherService;
        private readonly IUserService _userService;

        public TeacherController(IFullTeacherService fullTeacherService, ITeacherService teacherService, IUserService userService)
        {
            _fullTeacherService = fullTeacherService;
            _teacherService = teacherService;
            _userService = userService;
        }

        public ActionResult Index()
        {
            var p = _fullTeacherService.GetAllTeacher().Select(s => s.ToFullTeacherModel().ToGridTeacherModel());
            return View(p);
        }

        public ActionResult Create()
        {
            return RedirectToAction("CreateUser", new { area = "Administrator", controller = "User" });
        }

        public ActionResult Detail(int id)
        {
            return RedirectToAction("UserInformation", new { area = "Administrator", controller = "User", idUser = id });
        }

        public ActionResult Delete(int id)
        {
            return RedirectToAction("DeleteUser", new { area = "Administrator", controller = "User", idUser = id });
        }

        public ActionResult ToTeacher(int id)
        {
            var pupil = _fullTeacherService.SetFullTeacher(_teacherService.GetTeacherByIdUser(id).Id);
            var idTeacher = pupil.Teacher.Id;
            return RedirectToAction("UserInformation", new { area = "Administrator", controller = "User", idUser = idTeacher });
        }

        public ActionResult ToClassroom(int id)
        {
            return RedirectToAction("DetailClassRoom", new { area = "Administrator", controller = "ClassRoom", idUser = id });
        }


        public ActionResult AssignRole()
        {
            return View(_userService.GetAllNotTeacherUsers().Select(s=>s.ToUserModel()));
        }

        public ActionResult AddRole(int id)
        {
            return RedirectToAction("AddTeacherEdit", new { area = "Administrator", controller = "User", idUser = id });
        }

        public ActionResult A()
        {
            var p = _fullTeacherService.GetAllTeacher().Select(s => s.ToFullTeacherModel().ToGridTeacherModel());
            return View(p);
        }

        public ActionResult _ClassRoom(IEnumerable<ClassRoomModel> model)
        {
            return PartialView(model);
        }
    }
}