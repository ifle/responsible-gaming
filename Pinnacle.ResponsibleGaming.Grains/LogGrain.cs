using System.Threading.Tasks;
using Orleans;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Domain.Repositories;
using Pinnacle.ResponsibleGaming.IGrains;

namespace Pinnacle.ResponsibleGaming.Grains
{
    public class LogGrain : Grain, ILogGrain
    {
        public Task Add(Log log)
        {
            throw new System.NotImplementedException();
        }
    }
}
