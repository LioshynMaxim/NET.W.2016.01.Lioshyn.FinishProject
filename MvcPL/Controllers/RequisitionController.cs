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
        private readonly IRequisitionService _requisitionService;

        public RequisitionController(IRequisitionService requisitionService)
        {
            _requisitionService = requisitionService;
        }

        // GET: Requisition
        [ActionName("Index")]
        public ActionResult Index()
        {
            return View(_requisitionService.GetAllRequisition().Select(s => s.ToRequisitionModel()));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RequisitionModel requisitionModel)
        {

            //Validation
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

        public ActionResult Details(int? idRequisition)
        {
            if (idRequisition == null) return RedirectToAction("Index");
            var requisitionModel = _requisitionService.GetSomeRequisition(idRequisition.Value);
            return View(requisitionModel.ToRequisitionModel());
        }

        public ActionResult Edit(int? idRequisition)
        {
            if (idRequisition == null) return RedirectToAction("Index");
            var requisitionModel = _requisitionService.GetSomeRequisition(idRequisition.Value);
            return View(requisitionModel.ToRequisitionModel());
        }


        [HttpPost]
        public ActionResult Edit(RequisitionModel roleModel)
        {
            _requisitionService.UpdateRequisition(roleModel.ToBllRequisition());
            return View(_requisitionService.GetSomeRequisition(roleModel.Id).ToRequisitionModel());
        }

        
        public ActionResult Delete(int? idRequisition)
        {
            if (idRequisition == null) return RedirectToAction("Index");
            var requisitionModel = _requisitionService.GetSomeRequisition(idRequisition.Value);
            return View(requisitionModel.ToRequisitionModel());
        }


        [HttpPost]
        public ActionResult Delete(RequisitionModel roleModel)
        {
            var deleteRequisition = _requisitionService.GetSomeRequisition(roleModel.Id);
            _requisitionService.DeleteRequisition(deleteRequisition);
            return RedirectToAction("Index");
        }
    }
}