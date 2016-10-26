using System.Threading.Tasks;
using Orleans;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Domain.Repositories;
using Pinnacle.ResponsibleGaming.IGrains;

namespace Pinnacle.ResponsibleGaming.Infrastructure.RepositoriesWithOrleans
{
    public class LimitRepository : ILimitRepository
    {
        public  Task<Limit> GetCustomerLimitByLimitType(string customerId, LimitType limitType)
        {
            var limitGrain = GrainClient.GrainFactory.GetGrain<ICustomerLimitsGrain>(customerId);
            return limitGrain.Get(limitType);
        }

        public Task AddOrUpdate(Limit limit)
        {
            var limitGrain = GrainClient.GrainFactory.GetGrain<ICustomerLimitsGrain>(limit.CustomerId);
            return limitGrain.AddOrUpdate(limit);
        }
    }
}
