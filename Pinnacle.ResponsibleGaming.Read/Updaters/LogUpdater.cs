using System.Data.Entity;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Bus.Events;
using Pinnacle.ResponsibleGaming.Read.Mappers;
using Pinnacle.ResponsibleGaming.Read.Views;

namespace Pinnacle.ResponsibleGaming.Read.Updaters
{
    public class LogUpdater
    {
        private readonly DbContext _mainDbContext;

        public LogUpdater(DbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task Update(DepositLimitSet depositLimitSet)
        {

            var log = new Log().Map(depositLimitSet);
            _mainDbContext.Set<Log>().Add(log);

            await _mainDbContext.SaveChangesAsync();
        }
    }
}
