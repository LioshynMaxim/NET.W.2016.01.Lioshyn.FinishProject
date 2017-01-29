using System.Linq;
using System.Web.Mvc;
using BLL.Interfacies.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;

namespace MvcPL.Areas.Administrator.Controllers
{
    public class ClassRoomController : Controller
    {
        private readonly IUserService _userService;
        private readonly IClassRoomService _classRoomService;

        public ClassRoomController(IUserService userService, IClassRoomService classRoomService)
        {
            _userService = userService;
            _classRoomService = classRoomService;
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

        public ActionResult DeleteClassRoom()
        {
            return View(_classRoomService.GetAll().Select(s => s.ToClassRoomModel()));
        }

        public ActionResult EditClassRoom()
        {
            return View(_classRoomService.GetAll().Select(s => s.ToClassRoomModel()));
        }

        public ActionResult DetailClassRoom()
        {
            return View(_classRoomService.GetAll().Select(s => s.ToClassRoomModel()));
        }

        public ActionResult AddPupil()
        {
            return View(_classRoomService.GetAll().Select(s => s.ToClassRoomModel()));
        }

        public ActionResult AddTeacher()
        {
            return View(_classRoomService.GetAll().Select(s => s.ToClassRoomModel()));
        }
    }
}