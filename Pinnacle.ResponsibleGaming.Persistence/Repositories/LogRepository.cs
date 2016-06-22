using Pinnacle.ResponsibleGaming.Domain.Models;
using Pinnacle.ResponsibleGaming.Domain.Repositories;
using Pinnacle.ResponsibleGaming.Persistence.Contexts;


namespace Pinnacle.ResponsibleGaming.Persistence.Repositories
{
    public class LogRepository: ILogRepository
    {
        private readonly MainContext _mainDbContext;

        public LogRepository(MainContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public void Add(Log log)
        {
            _mainDbContext.Logs.Add(log);
        }
    }
}
