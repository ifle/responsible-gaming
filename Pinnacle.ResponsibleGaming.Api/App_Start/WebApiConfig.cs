using System.Web.Http;
using Pinnacle.ResponsibleGaming.Api.Filters;

namespace Pinnacle.ResponsibleGaming.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Filters.Add(new ValidateRequestAttribute());
            config.Filters.Add(new ExceptionHandlingAttribute());
            config.Filters.Add(new ValidateCustomerIdAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
