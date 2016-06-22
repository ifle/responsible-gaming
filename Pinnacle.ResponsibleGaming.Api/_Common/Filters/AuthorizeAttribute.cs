using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Microsoft.Practices.Unity;
using PinnacleSports.CustomerApi.Auth.PartnerAuth;
using PinnacleSports.CustomerApi.Auth.PartnerAuth.Interfaces;
using PinnacleSports.ResponsibleGaming.Admin.Api.Constants;
using PinnacleSports.ResponsibleGaming.Admin.Api.Extensions;

namespace PinnacleSports.ResponsibleGaming.Admin.Api.Filters
{
    public class AuthorizeAttribute : ActionFilterAttribute
    {
        [Dependency]
        public IPartnerAuthService PartnerAuthService { get; set; }

        public override async Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var token = HttpContext.Current.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(token))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new HttpError(ErrorMessages.AuthorizationHeaderMustBeProvided));
                return;
            }

            Guid guid;
            var isValidGuid = Guid.TryParse(token, out guid);

            if (isValidGuid)
            {
                PartnerAuthService = new PartnerAuthServiceWithIntegratedDbContext();//TODO (Cesar): To remove when I have DI working for ActionFilters
                var partner = await PartnerAuthService.GetPartnerDetails(new Guid(token));
                if (partner == null || !partner.IsActive)
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new HttpError(ErrorMessages.AuthorizationHeaderIsNotValid));
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new HttpError(ErrorMessages.AuthorizationHeaderDoesNotHaveValidFormat));
            }
          
        }
    }
}