using System.Threading.Tasks;
using Orleans;
using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.IGrains
{
	public interface ILimitGrain : IGrainWithStringKey
    {
        Task<Limit> Get(LimitType limitType);
        Task AddOrUpdate(Limit limit);
    }
}
