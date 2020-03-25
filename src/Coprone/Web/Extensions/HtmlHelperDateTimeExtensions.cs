using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Web
{
    public static class HtmlHelperDateTimeExtensions
    {
        public static HtmlString LocalDate(this IHtmlHelper helper, DateTime date)
        {
            // Must use MvcHtmlString to avoid encoding.
            return new HtmlString(String.Format("<span class=\"mytime\" utc =\"{0}\"></span>", date.ToString("o")));
        }
    }
}
