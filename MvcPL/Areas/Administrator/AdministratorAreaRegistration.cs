using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MvcPL.Areas.Administrator
{
    public class AdministratorAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Administrator";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administrator_default",
                "Administrator/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "MvcPL.Areas.Administrator.Controllers" }
            );
        }
    }
}