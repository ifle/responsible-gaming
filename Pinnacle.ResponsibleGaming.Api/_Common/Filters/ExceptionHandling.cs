using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http.Filters;
using log4net;
using Pinnacle.ResponsibleGaming.Domain._Common.Exceptions;

namespace Pinnacle.ResponsibleGaming.Api._Common.Filters
{
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public override void OnException(HttpActionExecutedContext actionContext)
        {
            if (actionContext.Exception is ConflictException)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Conflict)
                                   {
                                       Content = new StringContent(actionContext.Exception.Message)
                                   };
            }

            //actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, null, actionContext.Exception);
            _log.Error("Please, contact CSD.", actionContext.Exception);
        }
    }
}