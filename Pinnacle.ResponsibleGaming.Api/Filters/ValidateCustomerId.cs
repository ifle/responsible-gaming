using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Pinnacle.ResponsibleGaming.Application.Messages;
using Pinnacle.ResponsibleGaming.Application.Requests;

namespace Pinnacle.ResponsibleGaming.Api.Filters
{
    public class ValidateCustomerIdAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //Ignore Get methods
            if (actionContext.Request.Method == HttpMethod.Get) return;

            object customerId;
            actionContext.ActionArguments.TryGetValue("customerId", out customerId);

            //if customerId is in the route
            if (customerId != null)
            {
                //Assign customerId to the request 
                var customerRequest = actionContext.ActionArguments["request"] as CustomerRequest;
                if(customerRequest != null) customerRequest.CustomerId = customerId.ToString();

                //TODO (Cesar): Check, by calling another rest api, if there is an account associated to this customer ID
                //If, by any chance, the api is not available, proceed without validation
                var exists = true;  

                if (!exists)
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.NotFound)
                                             {
                                                 Content = new StringContent(SetDepositLimitMessages.CustomerIdDoesNotExist)
                                             };
                }
            }
        }
    }
}