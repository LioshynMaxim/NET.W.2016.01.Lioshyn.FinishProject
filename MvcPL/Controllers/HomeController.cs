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


        // GET: Home
        [ActionName("Index")]
        public ActionResult Index()
        {
            RequisitionEntity requisitionModel = new RequisitionEntity
            {
                BirthDay = null,
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

            _requisitionService.CreateRequisition(requisitionModel);
            //new RequisitionRepository(new SOYMModel()).Create(requisitionModel);

            return View();
        }
    }
}