using System.Data.Entity;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Application.Transactions;
using Pinnacle.ResponsibleGaming.Application._Common.Extensions;
using Pinnacle.ResponsibleGaming.Domain.Services;

namespace Pinnacle.ResponsibleGaming.Application.Handlers
{
    public class DisableDepositLimitHandler
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private DisableDepositLimitTransaction _disableDepositLimitTransaction;
        private readonly DepositLimitService _depositLimitService;
        private readonly LogService _logService;

        public DisableDepositLimitHandler(
           DisableDepositLimitTransaction disableDepositLimitTransaction,
            DepositLimitService depositLimitService,
            LogService logService

            )
        {
            _disableDepositLimitTransaction = disableDepositLimitTransaction;
            _depositLimitService = depositLimitService;
            _logService = logService;
        }

        public async Task Handle(DisableDepositLimit disableDepositLimit)
        {
            //Begin transaction
            _disableDepositLimitTransaction.Begin();

            //Disable deposit limit
            var depositLimit = await _depositLimitService.Disable(
                    disableDepositLimit.CustomerId,
                    disableDepositLimit.Author
                    );

            //Add log entry
            var log = depositLimit.ToLog();
            await _logService.Add(log);

            //Commit                
            _disableDepositLimitTransaction.Commit();

            //Log
            _log.Info(disableDepositLimit.SerializeAsKeyValues());
        }
    }
}
