using System.Web.Http;
using FluentValidation.WebApi;
using log4net.Config;

namespace Pinnacle.ResponsibleGaming.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FluentValidationModelValidatorProvider.Configure(GlobalConfiguration.Configuration);
            UnityConfig.RegisterComponents();
            OrleansConfig.InitializeGrainClient();
            XmlConfigurator.Configure();
        }
    }
}
