using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.Domain.Repositories
{
    public interface ILogRepository
    {
        Task Add(LogEntry logEntry);
    }
}