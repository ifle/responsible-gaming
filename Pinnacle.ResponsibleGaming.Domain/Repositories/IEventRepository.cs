using System.Collections.Generic;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.Domain.Repositories
{
    public interface IEventRepository
    {
        Task Insert(Event @event);
    }
}