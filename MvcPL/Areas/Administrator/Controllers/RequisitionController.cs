using System;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interfacies.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;
using MvcPL.Providers;

namespace MvcPL.Areas.Administrator.Controllers
{
    //[Authorize(Roles = "Administrator")]
    //[Authorize]
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
            return View(_requisitionService.GetAll().Select(s => s.ToRequisitionModel()));
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
                _requisitionService.Create(requisitionModel.ToBllRequisition());
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
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null) return RedirectToAction("Index");
                var requisitionModel = _requisitionService.GetById(id.Value);
                return View(requisitionModel.ToRequisitionModel());
            }
            catch (Exception)
            {
                return View();
            }
        }

        #endregion

        #region Edit

        public ActionResult Edit(int id)
        {
            return View(_requisitionService.GetById(id).ToRequisitionModel());
        }

        [HttpPost]
        public ActionResult Edit(RequisitionModel roleModel)
        {
            _requisitionService.Update(roleModel.ToBllRequisition());
            return View(_requisitionService.GetById(roleModel.Id).ToRequisitionModel());
        }

        #endregion

        #region Delete

        public ActionResult Delete(int id)
        {
            return View(_requisitionService.GetById(id).ToRequisitionModel());
        }

        [HttpPost]
        public ActionResult Delete(RequisitionModel roleModel)
        {
            _requisitionService.Delete(_requisitionService.GetById(roleModel.Id));
            return RedirectToAction("Index");
        }

        #endregion

        public ActionResult Registration(RequisitionModel roleModel)
        {
            var requisition = _requisitionService.GetById(roleModel.Id);
            
            new CustomMembershipProvider().CreateUser(requisition.ToRequisitionModel()
                .ToUserFromRequisitionModel(requisition.Surname, requisition.Surname + requisition.Name));

            //new CustomMembershipProvider().CreateUser(new UserModel()
            //{
            //    Name = requisition.Name,
            //    Surname = requisition.Surname,
            //    Patronymic = requisition.Patronymic,
            //    BirthDay = requisition.BirthDay,
            //    Login = requisition.Surname,
            //    Password = requisition.Surname + requisition.Name,
            //    City = requisition.City,
            //    District = requisition.District,
            //    Street = requisition.Street,
            //    Hous = requisition.Hous,
            //    Housing = requisition.Housing,
            //    Flat = requisition.Flat,
            //    Postcode = requisition.Postcode
            //});

            _requisitionService.Delete(requisition);
            return RedirectToAction("Index");
        }
    }
}