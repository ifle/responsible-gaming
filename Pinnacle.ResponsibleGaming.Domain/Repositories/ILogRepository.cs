using System.Collections.Generic;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.Domain.Repositories
{
    public interface ILogRepository
    {
        Task<List<Log>> GetAllLogs();
        Task<List<Log>> GetCustomerLogs(string customerId);
        Task Add(Log log);
    }
}