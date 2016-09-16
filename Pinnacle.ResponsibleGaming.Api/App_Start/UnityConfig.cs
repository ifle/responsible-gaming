using Microsoft.Practices.Unity;
using System.Web.Http;
using Pinnacle.ResponsibleGaming.Application.Handlers;
using Pinnacle.ResponsibleGaming.Domain.Repositories;
using Pinnacle.ResponsibleGaming.Domain.Services;
using Pinnacle.ResponsibleGaming.Infrastructure.Contexts;
using Pinnacle.ResponsibleGaming.Infrastructure.Repositories;
using Unity.WebApi;
using System.Data.Entity;

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




            //Context (UOW)
            container.RegisterType<DbContext, Context>(new HierarchicalLifetimeManager());

            //Handlers
            container.RegisterType<GetDepositLimitHandler, GetDepositLimitHandler>();
            container.RegisterType<SetDepositLimitHandler, SetDepositLimitHandler>();
            container.RegisterType<DisableDepositLimitHandler, DisableDepositLimitHandler>();

            //Services
            container.RegisterType<DepositLimitService, DepositLimitService>();
            container.RegisterType<LogService, LogService>();
            container.RegisterType<EventService, EventService>();

            //Repositories
            container.RegisterType<IDepositLimitRepository, DepositLimitRepository>();
            container.RegisterType<ILogRepository, LogRepository>();
            container.RegisterType<IEventRepository, EventRepository>();




            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}