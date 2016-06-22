using Microsoft.Practices.Unity;
using System.Web.Http;
using Pinnacle.ResponsibleGaming.Application.Contexts;
using Pinnacle.ResponsibleGaming.Application.Handlers;
using Pinnacle.ResponsibleGaming.Domain.Repositories;
using Pinnacle.ResponsibleGaming.Persistence.Contexts;
using Pinnacle.ResponsibleGaming.Domain.Validators;
using Pinnacle.ResponsibleGaming.Persistence.Repositories;
using Unity.WebApi;

namespace Pinnacle.ResponsibleGaming.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<MainContext, MainContext>(new PerThreadLifetimeManager());
            container.RegisterType<SetDepositLimitContext, SetDepositLimitContext>(new PerThreadLifetimeManager());
            container.RegisterType<IDepositLimitRepository, DepositLimitRepository>(new PerThreadLifetimeManager());
            container.RegisterType<ILogRepository, LogRepository>(new PerThreadLifetimeManager());
            container.RegisterType<SetDepositLimitHandler, SetDepositLimitHandler>(new PerThreadLifetimeManager());
            container.RegisterType<DepositLimitValidator, DepositLimitValidator>(new PerThreadLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}