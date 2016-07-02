using System;
using System.ServiceProcess;
using Pinnacle.ResponsibleGaming.Persistence.Contexts;
using Pinnacle.ResponsibleGaming.Read.Updaters;

namespace Pinnacle.ResponsibleGaming.Bus
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var servicesToRun = new ServiceBase[]
            {
                new ServiceBus()
            };

            if (Environment.UserInteractive)
            {
                var dbContext = new MainContext();
                var bus = new Bus(new LogUpdater(dbContext));
            }
            else
            {
                ServiceBase.Run(servicesToRun);
            }
        }
    }
}
