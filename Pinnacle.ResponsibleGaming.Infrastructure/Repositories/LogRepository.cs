using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Domain.Repositories;
using Pinnacle.ResponsibleGaming.Infrastructure.Contexts;

namespace Pinnacle.ResponsibleGaming.Infrastructure.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly MainContext _context;

        public LogRepository(MainContext context)
        {
            _context = context;
        }

        public async Task<List<Log>> GetLog()
        {
            return await _context.Logs.ToListAsync();
        }

        public Task<List<Log>> GetCustomerLog(string customerId)
        {
            throw new System.NotImplementedException();
        }

        public Task Add(Log log)
        {
            _context.Logs.Add(log);
            return  Task.FromResult(0);
        }
    }
}
