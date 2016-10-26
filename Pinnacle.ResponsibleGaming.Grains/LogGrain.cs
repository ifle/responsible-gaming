using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.IGrains;

namespace Pinnacle.ResponsibleGaming.Grains
{
    public class LogGrain : Grain, ILogGrain
    {
        private readonly List<LogEntry> _log = new List<LogEntry>();
        public Task<List<LogEntry>> Get()
        {
           return Task.FromResult(_log);
        }

        public Task Add(LogEntry logEntry)
        {
            _log.Add(logEntry);
            return TaskDone.Done;
        }
    }
}
