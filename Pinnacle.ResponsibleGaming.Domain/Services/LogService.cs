using System.Data.Entity;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Domain.Services
{
    public class LogService
    {
        private readonly DbContext _dbContext;

        public LogService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddLog(Log log)
        {
            _dbContext.Set<Log>().Add(log);
            await _dbContext.SaveChangesAsync();
        }
    }
}
