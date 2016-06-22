using System;
using System.Reflection;
using System.Web.Http.Filters;
using log4net;

namespace PinnacleSports.ResponsibleGaming.Admin.Api.Filters
{
    public class SplunkExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            var requestBody = GetBodyFromRequest(context);
            requestBody = requestBody.Replace(": ", "=").Replace("\"", "").Replace("{", "").Replace("}", "").Replace(", ", ",").Replace("\r\n", "").Replace("  "," ").Remove(0, 1);
            var message = string.Format(
                "ExceptionMessage={0}, " + 
                "Uri={1}, " + 
                "Controller={2}, " +
                "Method={3}, " + 
                "Version={4}, " +
                "{5}",
                context.Exception.Message,
                context.Request.RequestUri.AbsoluteUri,
                context.ActionContext.ControllerContext.Controller,
                context.Request.Method.Method,
                context.Request.Version,
                requestBody);
            log.Error(message);
        }

        private static string GetBodyFromRequest(HttpActionExecutedContext context)
        {
            string data;
            using (var stream = context.Request.Content.ReadAsStreamAsync().Result)
            {
                if (stream.CanSeek)
                {
                    stream.Position = 0;
                }
                data = context.Request.Content.ReadAsStringAsync().Result;
            }
            return data;
        }
    }
}