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
            AjaxOptions options = new AjaxOptions {UpdateTargetId = "text-muted"};

            var tag = ajaxHelper.ActionLink(linkText, action, new
            {
                Area = "Administrator",
                Controller = controller,
                id = idModel
            }, options);
            return MvcHtmlString.Create(tag.ToHtmlString());
        }
    }

}