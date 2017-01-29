using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.Interfacies.Services;
using MvcPL.Areas.Administrator.Models;
using MvcPL.Infrastructure.Mappers;
using NLog;

namespace MvcPL.Areas.Administrator.Controllers
{
    public class PupilController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPupilService _pupilService;
        private readonly IFullPupilService _fullPupilService;

        private Logger logger = LogManager.GetCurrentClassLogger();

        public PupilController(IUserService userService, IPupilService pupilService, IFullPupilService fullPupilService)
        {
            _userService = userService;
            _pupilService = pupilService;
            _fullPupilService = fullPupilService;
        }

        public ActionResult Index()
        {
            var pupil = _fullPupilService.GetAllFullPupil().Select(s => s.ToFullPupulModel());
            return View(pupil.Select(s=>s.ToGridPupilModel()));
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
            var pupil = _fullPupilService.SetFullPupil(_pupilService.GetUserPupilRole(id).Id);
            var idTeacher = pupil.Teacher.Id;
            return RedirectToAction("UserInformation", new { area = "Administrator", controller = "User", idUser = idTeacher });
        }

        public ActionResult ToClassroom(int id)
        {
            return RedirectToAction("Index", new { area = "Administrator", controller = "User", idUser = id });
        }


        public ActionResult AssignRole()
        {
           return View(_userService.GetAllNotPupilUsers().Select(s=>s.ToUserModel()));
        }

        public ActionResult AddRole(int id)
        {
            return RedirectToAction("AddPupilEdit", new { area = "Administrator", controller = "User", idUser = id });
        }
    }
}