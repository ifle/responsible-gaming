using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.IGrains;

namespace Pinnacle.ResponsibleGaming.Grains
{
    public class CustomerLimitsGrain : Grain, ICustomerLimitsGrain
    {
        private readonly Dictionary<string, Limit> _limits = new Dictionary<string, Limit>();
        public Task<Limit> Get(LimitType limitType)
        {
            Limit limit;
            var key = limitType.ToString();
            _limits.TryGetValue(key, out limit);
            return Task.FromResult(limit);
        }

        public Task AddOrUpdate(Limit limit)
        {
            var key = limit.LimitType.ToString();

            if (_limits.ContainsKey(key))
            {
                _limits[key] = limit;
            }
            else
            {
                _limits.Add(key,limit);
            }

            return TaskDone.Done;
        }
    }
}
