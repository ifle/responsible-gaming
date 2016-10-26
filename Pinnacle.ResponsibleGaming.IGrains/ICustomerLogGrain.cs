using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans;
using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.IGrains
{
	public interface ICustomerLogGrain : IGrainWithStringKey
    {
        Task<List<Log>> Get();
        Task Add(Log log);
    }
}
