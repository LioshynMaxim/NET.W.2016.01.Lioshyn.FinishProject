using System;
using System.Web.Mvc;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;

namespace MvcPL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRequisitionService _requisitionService;

        public HomeController(IRequisitionService requisitionService)
        {
            _requisitionService = requisitionService;
        }

        #region Test

        RequisitionEntity requisitionModel = new RequisitionEntity
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

        #endregion


        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create()
        {
            _requisitionService.CreateRequisition(requisitionModel);
            return RedirectToAction("Index");
        }
    }
}