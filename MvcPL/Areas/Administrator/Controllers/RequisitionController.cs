using System;
using System.Linq;
using System.Web.Mvc;
using BLL.Interfacies.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;

namespace MvcPL.Areas.Administrator.Controllers
{
    public class RequisitionController : Controller
    {
        private readonly IRequisitionService _requisitionService;

        public RequisitionController(IRequisitionService requisitionService)
        {
            _requisitionService = requisitionService;
        }

        #region Index

        [ActionName("Index")]
        public ActionResult Index()
        {
            return View(_requisitionService.GetAllRequisition().Select(s => s.ToRequisitionModel()));
        }

        #endregion
        
        #region Create

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RequisitionModel requisitionModel)
        {
            try
            {
                _requisitionService.CreateRequisition(requisitionModel.ToBllRequisition());
                return RedirectToAction("Details");
            }
            catch (Exception)
            {
                return View();
            }
        }

        #endregion

        #region Details

        [ActionName("Details")]
        public ActionResult Details(int? idRequisition)
        {
            try
            {
                if (idRequisition == null) return RedirectToAction("Index");
                var requisitionModel = _requisitionService.GetSomeRequisition(idRequisition.Value);
                return View(requisitionModel.ToRequisitionModel());
            }
            catch (Exception)
            {
                return View();
            }
        }

        #endregion

        #region Edit

        public ActionResult Edit(int idRequisition)
        {
            return View(_requisitionService.GetSomeRequisition(idRequisition).ToRequisitionModel());
        }

        [HttpPost]
        public ActionResult Edit(RequisitionModel roleModel)
        {
            _requisitionService.UpdateRequisition(roleModel.ToBllRequisition());
            return View(_requisitionService.GetSomeRequisition(roleModel.Id).ToRequisitionModel());
        }

        #endregion

        #region Delete

        public ActionResult Delete(int idRequisition)
        {
            return View(_requisitionService.GetSomeRequisition(idRequisition).ToRequisitionModel());
        }

        [HttpPost]
        public ActionResult Delete(RequisitionModel roleModel)
        {
            _requisitionService.DeleteRequisition(_requisitionService.GetSomeRequisition(roleModel.Id));
            return RedirectToAction("Index");
        }

        #endregion

    }
}