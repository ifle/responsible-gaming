﻿using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using Pinnacle.ResponsibleGaming.Domain._Common.Exceptions;

namespace Pinnacle.ResponsibleGaming.Api._Common.Filters
{
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionContext)
        {
            if (actionContext.Exception is ConflictException)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Conflict)
                                   {
                                       Content = new StringContent(actionContext.Exception.Message)
                                   };
            }
        }
    }
}