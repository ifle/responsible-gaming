using System;
using Orleans;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.IGrains;

namespace Pinnacle.ResponsibleGaming.SiloHost
{
    /// <summary>
    /// Orleans test silo host
    /// </summary>
    public class Program
    {
        static Orleans.Runtime.Host.SiloHost _siloHost;

        static void Main(string[] args)
        {
            // Orleans should run in its own AppDomain, we set it up like this
            AppDomain hostDomain = AppDomain.CreateDomain("OrleansHost", null,
                new AppDomainSetup()
                {
                    AppDomainInitializer = InitSilo
                });

            DoSomeClientWork();


            Console.WriteLine("Orleans Silo is running.\nPress Enter to terminate...");
            Console.ReadLine();

            // We do a clean shutdown in the other AppDomain
            hostDomain.DoCallBack(ShutdownSilo);
        }

        static void DoSomeClientWork()
        {
            // Orleans comes with a rich XML and programmatic configuration. Here we're just going to set up with basic programmatic config
            var config = Orleans.Runtime.Configuration.ClientConfiguration.LocalhostSilo(30000);
            GrainClient.Initialize(config);

            var limit = new Limit
            {
                CustomerId =  "cesarc",
                LimitType =    LimitType.DepositLimit
            };
            var limitGrain = GrainClient.GrainFactory.GetGrain<ILimitGrain>(limit.CustomerId);
            limitGrain.AddOrUpdate(limit);
            var result = limitGrain.Get(limit.CustomerId, limit.LimitType).Result;
            Console.WriteLine(result);

        }



        static void InitSilo(string[] args)
        {
            _siloHost = new Orleans.Runtime.Host.SiloHost(System.Net.Dns.GetHostName());
            // The Cluster config is quirky and weird to configure in code, so we're going to use a config file
            _siloHost.ConfigFileName = "OrleansConfiguration.xml";

            _siloHost.InitializeOrleansSilo();
            var startedok = _siloHost.StartOrleansSilo();
            if (!startedok)
                throw new SystemException(String.Format("Failed to start Orleans silo '{0}' as a {1} node", _siloHost.Name, _siloHost.Type));

        }

        static void ShutdownSilo()
        {
            if (_siloHost != null)
            {
                _siloHost.Dispose();
                GC.SuppressFinalize(_siloHost);
                _siloHost = null;
            }
        }
    }
}
