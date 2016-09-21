using Microsoft.Practices.Unity;
using System.Web.Http;
using Pinnacle.ResponsibleGaming.Application.Handlers;
using Pinnacle.ResponsibleGaming.Domain.Repositories;
using Pinnacle.ResponsibleGaming.Domain.Services;
using Pinnacle.ResponsibleGaming.Infrastructure.Contexts;
using Pinnacle.ResponsibleGaming.Infrastructure.Repositories;
using Unity.WebApi;
<<<<<<< HEAD
=======
using System.Data.Entity;
>>>>>>> feature/with_messaging

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



<<<<<<< HEAD

            //Contexts
            container.RegisterType<Context, Context>(new HierarchicalLifetimeManager());
=======
            //Contexts (UOW)
            container.RegisterType<ResponsibleGamingContext, ResponsibleGamingContext>(new HierarchicalLifetimeManager());
>>>>>>> feature/with_messaging

            //Handlers
            container.RegisterType<GetDepositLimitHandler, GetDepositLimitHandler>();
            container.RegisterType<SetDepositLimitHandler, SetDepositLimitHandler>();
            container.RegisterType<DisableDepositLimitHandler, DisableDepositLimitHandler>();

            //Services
<<<<<<< HEAD
            container.RegisterType<DepositLimitService, DepositLimitService>();

            //Repositories
            container.RegisterType<IDepositLimitRepository, DepositLimitRepository>();
=======
            container.RegisterType<LimitService, LimitService>();

            //Repositories
            container.RegisterType<ILimitRepository, LimitRepository>();
>>>>>>> feature/with_messaging
            container.RegisterType<ILogRepository, LogRepository>();




            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}