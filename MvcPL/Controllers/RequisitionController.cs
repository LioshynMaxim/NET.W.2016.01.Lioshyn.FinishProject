using System;
using System.Linq;
using System.Web.Mvc;
using BLL.Interfacies.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;

namespace MvcPL.Controllers
{
    public class RequisitionController : Controller
    {
        RequisitionModel requisitionModel = new RequisitionModel
        {
            BirthDay = DateTime.Now,
            City = string.Empty,
            District = string.Empty,
            Flat = int.MinValue,
            Hous = int.MinValue,
            Housing = int.MinValue,
            Name = string.Empty,
            Patronymic = string.Empty,
            Postcode = int.MinValue,
            Street = string.Empty,
            Surname = string.Empty
        };


        private readonly IRequisitionService _requisitionService;

        public RequisitionController(IRequisitionService requisitionService)
        {
            _requisitionService = requisitionService;
        }

        // GET: Requisition
        [ActionName("Index")]
        public ActionResult Index()
        {
            //var b = _requisitionService.GetSomeRequisition(8).ToRequisitionModel();
            return View("Index1",_requisitionService.GetAllRequisition().Select(s => s.ToRequisitionModel()));
            //return System.Web.UI.WebControls.View(b);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RequisitionModel requisitionModel)
        {
            requisitionModel.Name = requisitionModel.Name ?? "";
            requisitionModel.BirthDay = requisitionModel.BirthDay ?? DateTime.Now;
            requisitionModel.City = requisitionModel.City ?? "";
            requisitionModel.District = requisitionModel.District ?? "";
            requisitionModel.Flat = requisitionModel.Flat ?? default(int);
            requisitionModel.Hous = requisitionModel.Hous ?? default(int);
            requisitionModel.Housing = requisitionModel.Housing ?? default(int);
            requisitionModel.Patronymic = requisitionModel.Patronymic ?? "";
            requisitionModel.Postcode = requisitionModel.Postcode ?? default(int);
            requisitionModel.Street = requisitionModel.Street ?? "";
            requisitionModel.Surname = requisitionModel.Surname ?? "";


            _requisitionService.CreateRequisition(requisitionModel.ToBllRequisition());
            return RedirectToAction("Index");
        }
    }
}