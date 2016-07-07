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

        public SetDepositLimitHandler(
            DbContext dbContext,
            DepositLimitService depositLimitService,
            LogService logService

            )
        {
            _dbContext = dbContext;
            _depositLimitService = depositLimitService;
            _logService = logService;
        }

        public async Task Handle(SetDepositLimit setDepositLimit)
        {
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                //Set deposit limit
                var depositLimit =  await _depositLimitService.SetDepositLimit(setDepositLimit.CustomerId, setDepositLimit.Amount, setDepositLimit.PeriodInDays, setDepositLimit.StartDate, setDepositLimit.EndDate, setDepositLimit.Author);

                //Add log entry
                var log = depositLimit.ToLog();
                await _logService.AddLog(log);

                //Commit                
                dbContextTransaction.Commit();
            }
            _log.Info(setDepositLimit.SerializeAsKeyValues());
        }
    }
}
