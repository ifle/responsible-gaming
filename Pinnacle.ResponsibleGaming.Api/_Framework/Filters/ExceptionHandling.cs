using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http.Filters;
using Elmah;
using log4net;
using Pinnacle.ResponsibleGaming.Domain._Framework.Exceptions;

namespace Pinnacle.ResponsibleGaming.Api._Framework.Filters
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
                return;
            }
            if (actionContext.Exception is NotFoundException)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(actionContext.Exception.Message)
                };
                return;
            }

            ErrorSignal.FromCurrentContext().Raise(actionContext.Exception);
            _log.Error(actionContext.Exception);
        }
    }
}