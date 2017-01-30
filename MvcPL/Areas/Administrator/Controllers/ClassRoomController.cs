using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.Interfacies.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;
using NLog;

namespace MvcPL.Areas.Administrator.Controllers
{
    public class ClassRoomController : Controller
    {
        
        private readonly IPupilService _pupilService;
        private readonly IUserService _userService;
        private readonly IClassRoomService _classRoomService;
        private readonly IGeneralClassRoomService _generalClassRoomService;
        private readonly IFullPupilService _fullPupilService;
        private readonly IFullTeacherService _fullTeacherService;
        private Logger logger = LogManager.GetCurrentClassLogger();


        public ClassRoomController(IUserService userService, IClassRoomService classRoomService, IGeneralClassRoomService generalClassRoomService, IFullPupilService fullPupilService, IFullTeacherService fullTeacherService, IPupilService pupilService)
        {
            _userService = userService;
            _classRoomService = classRoomService;
            _generalClassRoomService = generalClassRoomService;
            _fullPupilService = fullPupilService;
            _fullTeacherService = fullTeacherService;
            _pupilService = pupilService;
        }

        public ActionResult Index()
        {
            return View(_classRoomService.GetAll().Select(s=>s.ToClassRoomModel()));
        }

        public ActionResult AddClassRoom()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddClassRoom(ClassRoomModel model)
        {
            _classRoomService.Create(model.ToBllClassRoom());
            return RedirectToAction("Index");
        }

        public ActionResult DeleteClassRoom(int id)
        {
            return View(_classRoomService.GetById(id).ToClassRoomModel());
        }

        [HttpPost]
        public ActionResult DeleteClassRoom(ClassRoomModel model)
        {
            _classRoomService.Delete(_classRoomService.GetById(model.Id));
            return RedirectToAction("Index");
        }

        public ActionResult EditClassRoom(int id)
        {
            return View(_classRoomService.GetById(id).ToClassRoomModel());
        }

        [HttpPost]
        public ActionResult EditClassRoom(ClassRoomModel model)
        {
            _classRoomService.Update(model.ToBllClassRoom());
            return RedirectToAction("Index");
        }

        public ActionResult _ClassRoom(ClassRoomModel model)
        {
            return PartialView(model);
        }

        public ActionResult _Pupils(IEnumerable<PupilModel> model)
        {
            return PartialView(model);
        }

        public ActionResult _Teacher(TeacherModel model)
        {
            return PartialView(model);
        }

        public ActionResult DetailClassRoom(int id)
        {
            return View(_generalClassRoomService.GetByIdClassRoom(id).ToGeneralClassRoomModel());
        }

        public ActionResult AddPupil(int id)
        {
            var pupil = _fullPupilService.GetAllFullPupil().Select(s => s.ToFullPupulModel());
            return View(pupil.Select(s => s.ToGridPupilClassRoomModel()));
        }

        public ActionResult AddPupilIClassRoom(int id, int idClassRoom)
        {
            _pupilService.AddPupilToClassRoom(id,idClassRoom);
            return RedirectToAction("AddPupil");
        }

        public ActionResult AddTeacher()
        {
            return View(_classRoomService.GetAll().Select(s => s.ToClassRoomModel()));
        }
    }
}