using System.Data.Entity;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Application._Common.Extensions;
using Pinnacle.ResponsibleGaming.Domain.Services;

namespace Pinnacle.ResponsibleGaming.Application.Handlers
{
    public class SetDepositLimitHandler
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DbContext _dbContext;
        private readonly DepositLimitService _depositLimitService;
        private readonly LogService _logService;
        private readonly EventService _eventService;

        public SetDepositLimitHandler(
            DbContext dbContext,
            DepositLimitService depositLimitService,
            LogService logService,
            EventService eventService

            )
        {
            _dbContext = dbContext;
            _depositLimitService = depositLimitService;
            _logService = logService;
            _eventService = eventService;
        }

        public async Task Handle(SetDepositLimit setDepositLimit)
        {
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                //Set deposit limit
                var depositLimit =  await _depositLimitService.SetDepositLimit(setDepositLimit.ToDepositLimit());

                //Add log entry
                var log = depositLimit.ToLog();
                await _logService.AddLog(log);

                //Add events
                await _eventService.AddEvents(depositLimit.Events);

                //Commit                
                dbContextTransaction.Commit();
            }
            _log.Info(setDepositLimit.SerializeAsKeyValues());
        }
    }
}
