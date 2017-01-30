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
        private readonly IClassRoomService _classRoomService;
        private readonly IFullPupilService _fullPupilService;

        private Logger logger = LogManager.GetCurrentClassLogger();

        public PupilController(IUserService userService, IPupilService pupilService, IFullPupilService fullPupilService, IClassRoomService classRoomService)
        {
            _userService = userService;
            _pupilService = pupilService;
            _fullPupilService = fullPupilService;
            _classRoomService = classRoomService;
        }

        public ActionResult Index()
        {
            var pupil = _fullPupilService.GetAllFullPupil().Select(s => s.ToFullPupulModel());
            return View(pupil.Select(s=>s.ToGridPupilClassRoomModel()));
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

       

        public ActionResult DeleteClassRoom(int id)
        {
            var p = _pupilService.GetUserPupilRole(id);
            var pupil = _fullPupilService.SetFullPupil(p.Id);
            return View(pupil.ToFullPupulModel().ToGridPupilClassRoomModel());
        }

        [HttpPost]
        public ActionResult DeleteClassRoom(GridClassroomModel model)
        {
            var id = _pupilService.GetUserPupilRole(model.IdUser).Id;
            _pupilService.DeletePupilToClassRoom(id,model.IdClassRoom);
            return RedirectToAction("Index");
        }

        public ActionResult AssignRole()
        {
           return View(_userService.GetAllNotPupilUsers().Select(s=>s.ToUserModel()));
        }

        public ActionResult AddRole(int id)
        {
            return RedirectToAction("AddPupilEdit", new { area = "Administrator", controller = "User", idUser = id });
        }

        public ActionResult InClassRoom(int id)
        {
            var p = _classRoomService.GetAll().Select(s => s.ToClassRoomModel().ToGridClassRoomModelWhithIdUser(id));
            return View(p);
        }
        public ActionResult ToClassroom(int id, int idClassRoom)
        {
            var i = _pupilService.GetUserPupilRole(id).Id;
            _pupilService.AddPupilToClassRoom(i, idClassRoom);
            return RedirectToAction("Index");
        }
    }
}