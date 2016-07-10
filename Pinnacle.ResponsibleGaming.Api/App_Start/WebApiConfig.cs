using System.Web.Http;
using Newtonsoft.Json;
using Pinnacle.ResponsibleGaming.Api._Framework.Filters;
using WebApi.Hal;

namespace Pinnacle.ResponsibleGaming.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Filters.Add(new ValidateRequestAttribute());
            config.Filters.Add(new ExceptionHandlingAttribute());           
            config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            GlobalConfiguration.Configuration.Formatters.Add(new JsonHalMediaTypeFormatter());

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
