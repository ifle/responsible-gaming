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

        public Task Add(LogEntry logEntry)
        {
            _context.Log.Add(logEntry);
            return  Task.FromResult(0);
        }
    }
}
