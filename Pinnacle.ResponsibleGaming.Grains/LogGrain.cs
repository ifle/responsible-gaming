using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.IGrains;

namespace Pinnacle.ResponsibleGaming.Grains
{
    public class LogGrain : Grain, ILogGrain
    {
        private readonly List<Log> _log = new List<Log>();
        public Task<List<Log>> Get()
        {
           return Task.FromResult(_log);
        }

        public Task Add(Log log)
        {
            _log.Add(log);
            return TaskDone.Done;
        }
    }
}