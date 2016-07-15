using Microsoft.Practices.Unity;
using System.Web.Http;
using Pinnacle.ResponsibleGaming.Application.Handlers;
using Pinnacle.ResponsibleGaming.Application.Contexts;
using Pinnacle.ResponsibleGaming.Domain.Repositories;
using Pinnacle.ResponsibleGaming.Domain.Services;
using Pinnacle.ResponsibleGaming.Infrastructure.Contexts;
using Pinnacle.ResponsibleGaming.Infrastructure.Repositories;
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




            //Contexts
            container.RegisterType<Context, Context>(new HierarchicalLifetimeManager());
            container.RegisterType<ISetDepositLimitContext, Context>(new HierarchicalLifetimeManager());
            container.RegisterType<IDisableDepositLimitContext, Context>(new HierarchicalLifetimeManager());

            //Handlers
            container.RegisterType<GetDepositLimitHandler, GetDepositLimitHandler>();
            container.RegisterType<SetDepositLimitHandler, SetDepositLimitHandler>();
            container.RegisterType<DisableDepositLimitHandler, DisableDepositLimitHandler>();

            //Services
            container.RegisterType<DepositLimitService, DepositLimitService>();
            container.RegisterType<LogService, LogService>();

            //Repositories
            container.RegisterType<IDepositLimitRepository, DepositLimitRepository>();
            container.RegisterType<ILogRepository, LogRepository>();




            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}