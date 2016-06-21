using System.Web.Http.Filters;
using Elmah;

namespace PinnacleSports.ResponsibleGaming.Admin.Api.Filters
{
    public class ElmahExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnException(actionExecutedContext);
            ErrorSignal.FromCurrentContext().Raise(actionExecutedContext.Exception);
        }
    }
}