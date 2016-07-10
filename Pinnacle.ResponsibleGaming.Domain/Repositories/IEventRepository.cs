using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Domain.Repositories
{
    public interface IEventRepository
    {
        Task Insert(Event @event);
    }
}