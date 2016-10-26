using System.Collections.Generic;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.Domain.Repositories
{
    public interface ILogRepository
    {
        Task<List<Log>> GetLog();
        Task<List<Log>> GetCustomerLog(string customerId);
        Task Add(Log log);
    }
}