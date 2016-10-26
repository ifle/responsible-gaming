using System.Threading.Tasks;
using Orleans;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Domain.Repositories;
using Pinnacle.ResponsibleGaming.IGrains;

namespace Pinnacle.ResponsibleGaming.Infrastructure.RepositoriesWithOrleans
{
    public class LogRepository : ILogRepository
    {
        public Task Add(Log log)
        {
           var logGrain = GrainClient.GrainFactory.GetGrain<ILogGrain>(0);
           return logGrain.Add(log);
        }
    }
}
