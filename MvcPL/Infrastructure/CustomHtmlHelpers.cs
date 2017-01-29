using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcPL.Infrastructure
{
    public static class CustomHtmlHelpers
    {
        public static IHtmlString Date(this HtmlHelper helper, string name, object value)
        {
            return Date(helper, name, value, null);
        }

        public static IHtmlString Date(this HtmlHelper helper, string name, object value, object htmlAttributes)
        {
            var tagBuilder = new TagBuilder("input");
            tagBuilder.Attributes["name"] = name;
            tagBuilder.Attributes["value"] = value.ToString();
            tagBuilder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            return MvcHtmlString.Create(tagBuilder.ToString());
        }
    }

    public static class DatetimeHelpers
    {
        public static IHtmlString Date(this HtmlHelper helper, string name, object value)
        {
            return Date(helper, name, value, null);
        }

        public static IHtmlString Date(this HtmlHelper helper, string name, object value, object htmlAttributes)
        {
            var tagBuilder = new TagBuilder("input");
            tagBuilder.Attributes["name"] = name;
            tagBuilder.Attributes["value"] = value.ToString();
            tagBuilder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            return MvcHtmlString.Create(tagBuilder.ToString());
        }
    }
}