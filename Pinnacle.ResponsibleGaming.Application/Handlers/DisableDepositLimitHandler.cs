using System.Data.Entity;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Application._Common.Extensions;
using Pinnacle.ResponsibleGaming.Domain.Services;

namespace Pinnacle.ResponsibleGaming.Application.Handlers
{
    public class DisableDepositLimitHandler
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DbContext _dbContext;
        private readonly DepositLimitService _depositLimitService;
        private readonly LogService _logService;

        public DisableDepositLimitHandler(
            DbContext dbContext,
            DepositLimitService depositLimitService,
            LogService logService

            )
        {
            _dbContext = dbContext;
            _depositLimitService = depositLimitService;
            _logService = logService;
        }

        public async Task Handle(DisableDepositLimit disableDepositLimit)
        {
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                //Disable deposit limit
                var depositLimit = await _depositLimitService.DisableDepositLimit(disableDepositLimit.CustomerId, disableDepositLimit.Author);

                //Add log entry
                var log = depositLimit.ToLog();
                await _logService.AddLog(log);

                //Commit                
                dbContextTransaction.Commit();
            }
            _log.Info(disableDepositLimit.SerializeAsKeyValues());
        }
    }
}
