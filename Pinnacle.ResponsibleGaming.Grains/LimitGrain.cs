using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.IGrains;

namespace Pinnacle.ResponsibleGaming.Grains
{
    public class LimitGrain : Grain, ILimitGrain
    {
        private Dictionary<string, Limit> _limits = new Dictionary<string, Limit>();
        public Task<Limit> Get(string customerId, LimitType limitType)
        {
            return Task.FromResult(_limits[limitType.ToString()]);
        }

        public Task AddOrUpdate(Limit limit)
        {
            _limits.Add(limit.LimitType.ToString(), limit);
            return TaskDone.Done;
        }
    }
}
