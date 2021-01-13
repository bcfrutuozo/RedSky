using System;
using System.Web.Mvc;
using log4net;

namespace RedSky.Presentation.Web.Filters
{
    public class Log4NetExceptionFilter : IExceptionFilter
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void OnException(ExceptionContext context)
        {
            Exception ex = context.Exception;

            Logger.Error(ex.Message);
        }
    }
}