using System.Threading.Tasks;
using Orleans;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Domain.Repositories;
using Pinnacle.ResponsibleGaming.IGrains;

namespace Pinnacle.ResponsibleGaming.Infrastructure.RepositoriesWithOrleans
{
    public class LimitRepository : ILimitRepository
    {
        public  Task<Limit> Get(string customerId, LimitType limitType)
        {
            var limitGrain = GrainClient.GrainFactory.GetGrain<ILimitGrain>(customerId);
            return limitGrain.Get(customerId, limitType);
        }

        public Task AddOrUpdate(Limit limit)
        {
            var limitGrain = GrainClient.GrainFactory.GetGrain<ILimitGrain>(limit.CustomerId);
            return limitGrain.AddOrUpdate(limit);
        }
    }
}
