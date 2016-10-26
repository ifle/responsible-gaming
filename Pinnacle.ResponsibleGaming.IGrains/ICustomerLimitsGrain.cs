using System.Threading.Tasks;
using Orleans;
using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.IGrains
{
	public interface ICustomerLimitsGrain : IGrainWithStringKey
    {
        Task<Limit> Get(LimitType limitType);
        Task AddOrUpdate(Limit limit);
    }
}
