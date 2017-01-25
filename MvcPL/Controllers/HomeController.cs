using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using System.Xml;
using System.Xml.Linq;
using BLL.Interfacies.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;
using NLog;

namespace MvcPL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRequisitionService _service;
        private readonly IRoleService _roleService;
        private Logger logger = LogManager.GetCurrentClassLogger();

        public HomeController(IRequisitionService roleService, IRoleService roleService1)
        {
            _service = roleService;
            _roleService = roleService1;
        }


        public ActionResult Index()
        {
            var doc = XDocument.Load(Server.MapPath("~/App_Data/MainInformation.xml")).Element("Landing")?.Elements();
            ViewBag.ArticleTitle = doc.SingleOrDefault(s => s.Name == "ArticleTitle")?.Value;
            ViewBag.ArticleBody = doc.SingleOrDefault(s => s.Name == "ArticleBody")?.Value;
            if (Request.IsAjaxRequest()) return PartialView();
            return View("Index");
        }

        public ActionResult Home()
        {
            if (Request.IsAjaxRequest()) return PartialView();
            return View();
        }

        public ActionResult AboutSchool()
        {
            if (Request.IsAjaxRequest()) return PartialView();
            return View();
        }

        public ActionResult Contacts()
        {
            if (Request.IsAjaxRequest()) return PartialView();
            return View();
        }

        public ActionResult Requisition()
        {
            ViewBag.Requisition = "Requisition";
            if (Request.IsAjaxRequest()) return PartialView();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Requisition(RequisitionModel requisitionModel)
        {
            ViewBag.Requisition = "Requisition";
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Error while requisition.");
                }
                else
                {
                    _service.Create(requisitionModel.ToBllRequisition());
                    ViewBag.Requisition = "Requisition success!";
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);

            }
            return View();
        }

        public ActionResult Login()
        {
            if (Request.IsAjaxRequest()) return PartialView();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid) return View();
            if (Membership.ValidateUser(loginModel.Login, loginModel.Password))
            {
                FormsAuthentication.SetAuthCookie(loginModel.Login, false);
                
            }
            else
            {
                ModelState.AddModelError("login", "Wrong password or email");
            }
            return View();
        }
    }
}
