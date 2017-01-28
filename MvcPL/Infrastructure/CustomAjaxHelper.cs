using System.Web.Mvc;
using System.Web.Mvc.Ajax;



namespace MvcPL.Infrastructure
{
    public static class CustomAjaxHelper
    {
        public static MvcHtmlString AdminMenuMainLink(
            this AjaxHelper ajaxHelper, 
            string linkText,
            string action,
            string controller,
            int idModel,
            AjaxOptions ajaxOptions)
        {
            ajaxOptions.UpdateTargetId = "text-muted";

            return ajaxHelper.ActionLink(linkText, action, new
            {
                Area = "Administrator",
                Controller = controller,
                id = idModel
            }, ajaxOptions);
            
        }
    }

}