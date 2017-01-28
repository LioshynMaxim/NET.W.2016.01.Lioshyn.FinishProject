using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Infrastructure
{
    public static class CustomHtmlHelpers
    {
        public static MvcHtmlString DetailForm(this HtmlHelper html, string[] list)
        {
            TagBuilder tag = new TagBuilder("div");
            TagBuilder itemHr = new TagBuilder("hr");
            tag.InnerHtml += itemHr.ToString();
            TagBuilder itemDl = new TagBuilder("dl");
            itemDl.AddCssClass("dl-horizontal");
            tag.InnerHtml += itemDl.ToString();
            foreach (var s in list)
            {
                TagBuilder itemTag = new TagBuilder("dt");
                itemTag.SetInnerText(s);
                tag.InnerHtml += itemTag.ToString();
            }

            return MvcHtmlString.Create(tag.ToString());
        }
    }
}