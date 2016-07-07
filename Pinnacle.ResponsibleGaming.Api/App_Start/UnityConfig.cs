using System.Data.Entity;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Pinnacle.ResponsibleGaming.Application.Handlers;
using Pinnacle.ResponsibleGaming.Domain.Queries;
using Pinnacle.ResponsibleGaming.Domain.Services;
using Pinnacle.ResponsibleGaming.Persistence.Contexts;
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
            container.RegisterType<DbContext, MainContext>(new HierarchicalLifetimeManager());

            //Handlers
            container.RegisterType<GetDepositLimitHandler, GetDepositLimitHandler>();
            container.RegisterType<SetDepositLimitHandler, SetDepositLimitHandler>();
            container.RegisterType<DisableDepositLimitHandler, DisableDepositLimitHandler>();

            //Services
            container.RegisterType<DepositLimitService, DepositLimitService>();
            container.RegisterType<LogService, LogService>();

            //Queries
            container.RegisterType<DepositLimitQuery, DepositLimitQuery>();


           

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}