using System.Data.Entity;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.Domain.Repositories
{
    public class LogRepository 
    {
        private readonly DbContext _dbContext;

        public LogRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Insert(Log log)
        {
            _dbContext.Set<Log>().Add(log);
            await _dbContext.SaveChangesAsync();
        }
    }
}
