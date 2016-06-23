using Microsoft.Practices.Unity;
using System.Web.Http;
using Pinnacle.ResponsibleGaming.Application.Handlers;
using Pinnacle.ResponsibleGaming.Domain.Contexts;
using Pinnacle.ResponsibleGaming.Domain.Queries;
using Pinnacle.ResponsibleGaming.Domain.Validators;
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

            container.RegisterType<MainContext, MainContext>(new HierarchicalLifetimeManager());
            container.RegisterType<DepositLimitQuery, DepositLimitQuery>();
            container.RegisterType<GetDepositLimitHandler, GetDepositLimitHandler>();
            container.RegisterType<SetDepositLimitHandler, SetDepositLimitHandler>();
            container.RegisterType<DepositLimitValidator, DepositLimitValidator>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}