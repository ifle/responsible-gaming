using System.Threading.Tasks;
using Orleans;
using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.IGrains
{
	public interface ILogGrain : IGrainWithIntegerKey
    {
        Task Add(Log log);
    }
}
