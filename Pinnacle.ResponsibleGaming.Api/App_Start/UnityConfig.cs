using System.Data.Entity;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Pinnacle.ResponsibleGaming.Domain.Repositories;
using Pinnacle.ResponsibleGaming.Domain.Services;
using Pinnacle.ResponsibleGaming.Persistence.Contexts;
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




            //Contexts
            container.RegisterType<DbContext, Context>(new HierarchicalLifetimeManager());

            //Handlers
            container.RegisterType<Application.GetDepositLimit.Handler, Application.GetDepositLimit.Handler>();
            container.RegisterType<Application.SetDepositLimit.Handler, Application.SetDepositLimit.Handler>();
            container.RegisterType<Application.DisableDepositLimit.Handler, Application.DisableDepositLimit.Handler>();

            //Transactions
            container.RegisterType<Application.SetDepositLimit.IContext, SetDepositLimitContext>();
            container.RegisterType<Application.DisableDepositLimit.IContext, DisableDepositLimitContext>();

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