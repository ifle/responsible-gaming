using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Domain.Repositories
{
    public interface ILogRepository
    {
        Task Insert(Log log);
    }
}