using ExamenFinalMoneda.Services.Log;
using System.Web.Mvc;

namespace ExamenFinalMoneda.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            ILog log = new ProductionLog();

            if (filterContext.ExceptionHandled)
            {
                return;
            }

            log.WriteLog(filterContext.Exception.Message);
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.csthml"
            };
            filterContext.ExceptionHandled = true;
        }
    }
}