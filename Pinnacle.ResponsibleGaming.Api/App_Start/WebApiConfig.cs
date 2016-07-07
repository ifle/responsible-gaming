using System.Web.Http;
using Newtonsoft.Json;
using Pinnacle.ResponsibleGaming.Api._Common.Binders;
using Pinnacle.ResponsibleGaming.Api._Common.Filters;
using Pinnacle.ResponsibleGaming.Application.Requests;

namespace Pinnacle.ResponsibleGaming.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Filters.Add(new ValidateRequestAttribute());
            config.Filters.Add(new ExceptionHandlingAttribute());
            config.ParameterBindingRules.Insert(0, descriptor => descriptor.ParameterType.IsSubclassOf(typeof(CustomerRequest)) ? new BodyAndUriParameterBinding(descriptor) : null);
            config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());

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
