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
            ajaxOptions.UpdateTargetId = "informational";
            ajaxOptions.LoadingElementId = "loading";

            return ajaxHelper.ActionLink(linkText, action, new
            {
                Area = "Administrator",
                Controller = controller,
                id = idModel
            }, ajaxOptions);
        }

        public static MvcHtmlString AdminMenuCreateLink(
            this AjaxHelper ajaxHelper,
            string action,
            string controller,
            AjaxOptions ajaxOptions)
        {
            ajaxOptions.UpdateTargetId = "informational";
            ajaxOptions.LoadingElementId = "loading";

            return ajaxHelper.ActionLink("Create", action, new
            {
                Area = "Administrator",
                Controller = controller
            }, ajaxOptions);
        }

        public static MvcHtmlString AdminMainMenu(
            this AjaxHelper ajaxHelper,
            string linkText,
            string controller,
            AjaxOptions ajaxOptions)
        {
            ajaxOptions.UpdateTargetId = "informationalBody";
            ajaxOptions.LoadingElementId = "loading";

            return ajaxHelper.ActionLink(linkText, "Index", new
            {
                Area = "Administrator",
                Controller = controller
            }, ajaxOptions);
        }
    }



}