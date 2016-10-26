using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans;
using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.IGrains
{
	public interface ILogGrain : IGrainWithIntegerKey
    {
        Task<List<LogEntry>> Get();
        Task Add(LogEntry logEntry);
    }
}
