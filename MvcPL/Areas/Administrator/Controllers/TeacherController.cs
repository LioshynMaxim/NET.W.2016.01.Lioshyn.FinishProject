using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.Interfacies.Services;
using MvcPL.Areas.Administrator.Models;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;

namespace MvcPL.Areas.Administrator.Controllers
{
    public class TeacherController : Controller
    {

        private readonly IFullTeacherService _fullTeacherService;
        private readonly ITeacherService _teacherService;
        private readonly IClassRoomService _classRoomService;
        private readonly IUserService _userService;

        public TeacherController(IFullTeacherService fullTeacherService, ITeacherService teacherService, IUserService userService, IClassRoomService classRoomService)
        {
            _fullTeacherService = fullTeacherService;
            _teacherService = teacherService;
            _userService = userService;
            _classRoomService = classRoomService;
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
            return RedirectToAction("DetailClassRoom", new { area = "Administrator", controller = "ClassRoom", id = id });
        }


        public ActionResult AssignRole()
        {
            return View(_userService.GetAllNotTeacherUsers().Select(s=>s.ToUserModel()));
        }

        public ActionResult AddRole(int id)
        {
            return RedirectToAction("AddTeacherEdit", new { area = "Administrator", controller = "User", idUser = id });
        }

        public ActionResult InfoTeacher(int id)
        {
            var teacher = _fullTeacherService.SetFullTeacher(_teacherService.GetTeacherByIdUser(id).Id);
            return View(teacher.ToFullTeacherModel().ToGridTeacherModel());
        }

        public ActionResult DeleteClassRoom(int id, int idClassRoom)
        {
            var pupil = _fullTeacherService.SetFullTeacher(_teacherService.GetTeacherByIdUser(id).Id);
            return View(pupil.ToFullTeacherModel().ToGridTeacherModel().ToGridTeacherDeleteModel(idClassRoom));
        }

        [HttpPost]
        public ActionResult DeleteClassRoom(GridTeacherDeleteModel model)
        {
            _teacherService.DeleteTeacherToClassRoom(_teacherService.GetTeacherByIdUser(model.IdUser).Id,model.ClassRoom.Id);
            return RedirectToAction("Index");
        }

        public ActionResult InClassRoom(int id)
        {
            var p = _classRoomService.GetAll().Select(s => s.ToClassRoomModel().ToGridClassRoomModelWhithIdUser(id));
            return View(p);
        }

        public ActionResult AddToClassroom(int id, int idClassRoom)
        {
            _teacherService.AddTeacherToClassRoom(_teacherService.GetTeacherByIdUser(id).Id, idClassRoom);
            return RedirectToAction("Index");
        }

        public ActionResult _ClassRoom(IEnumerable<ClassRoomModel> model)
        {
            return PartialView(model);
        }
    }
}