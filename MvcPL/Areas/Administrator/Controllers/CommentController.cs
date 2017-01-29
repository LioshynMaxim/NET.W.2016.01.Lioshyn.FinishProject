using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Areas.Administrator.Controllers
{
    public class CommentController : Controller
    {
        // GET: Administrator/Comment
        public ActionResult Index()
        {
            return View();
        }
    }
}