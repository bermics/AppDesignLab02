using System;
using System.Text;
using System.Web.Mvc;
using GadgetHub.WebUI.Models;

namespace GadgetHub.WebUI.HtmlHelpers
{
    public static class PageHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PageProperties pageProperties, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 1; i <= pageProperties.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.SetInnerText(i.ToString());

                if (i == pageProperties.CurrentPage)
                    tag.AddCssClass("btn btn-primary selected");
                else
                    tag.AddCssClass("btn btn-default");

                result.Append(tag.ToString());
            }

            return MvcHtmlString.Create(result.ToString());
        }
    }
}
