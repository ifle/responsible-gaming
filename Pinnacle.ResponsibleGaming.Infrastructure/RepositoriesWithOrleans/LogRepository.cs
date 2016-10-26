using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Domain.Repositories;
using Pinnacle.ResponsibleGaming.IGrains;

namespace Pinnacle.ResponsibleGaming.Infrastructure.RepositoriesWithOrleans
{
    public class LogRepository : ILogRepository
    {
        public async Task<List<Log>> GetLog()
        {
            var logGrain = GrainClient.GrainFactory.GetGrain<ILogGrain>(0);
            return await logGrain.Get();
        }

        public async Task<List<Log>> GetCustomerLog(string customerId)
        {
            var customerLogGrain = GrainClient.GrainFactory.GetGrain<ICustomerLogGrain>(customerId);
            return await customerLogGrain.Get();
        }

        public Task Add(Log log)
        {
           var logGrain = GrainClient.GrainFactory.GetGrain<ILogGrain>(0);
           return logGrain.Add(log);
        }
    }
}
