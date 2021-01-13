using System.Runtime.ExceptionServices;
using System.Web.Mvc;
using RedSky.Presentation.Web.Filters;

namespace RedSky.Presentation.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new HandleExceptionAttribute());
            filters.Add(new Log4NetExceptionFilter());
        }
    }
}