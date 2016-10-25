using System.Threading.Tasks;
using Orleans;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.IGrains;

namespace Pinnacle.ResponsibleGaming.Grains
{
    public class LimitGrain : Grain, ILimitGrain
    {
        public Task<Limit> Get(string customerId, LimitType limitType)
        {
            throw new System.NotImplementedException();
        }

        public void AddOrUpdate(Limit limit)
        {
            throw new System.NotImplementedException();
        }
    }
}
