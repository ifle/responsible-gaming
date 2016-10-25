using System.Threading.Tasks;
using Orleans;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Domain.Repositories;

namespace Pinnacle.ResponsibleGaming.IGrains
{
	public interface ILimitGrain : IGrainWithStringKey, ILimitRepository
    {
    }
}
