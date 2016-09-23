using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.Domain.Repositories
{
    public interface ILogRepository
    {
        Log Add(Log log);
    }
}