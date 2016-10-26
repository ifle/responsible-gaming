using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.IGrains;

namespace Pinnacle.ResponsibleGaming.Grains
{
    public class CustomerLogGrain : Grain, ICustomerLogGrain
    {
        private readonly List<Log> _log = new List<Log>();
        public Task<List<Log>> Get()
        {
           return Task.FromResult(_log);
        }

        public async Task Add(Log log)
        {
            _log.Add(log);
            var logGrain = GrainClient.GrainFactory.GetGrain<ILogGrain>(0);
            await logGrain.Add(log);
        }
    }
}
