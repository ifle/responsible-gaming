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
    public class SetDepositLimitHandler
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly SetDepositLimitTransaction _setDepositLimitTransaction;
        private readonly DepositLimitService _depositLimitService;
        private readonly LogService _logService;
        private readonly EventService _eventService;

        public SetDepositLimitHandler(
            SetDepositLimitTransaction setDepositLimitTransaction,
            DepositLimitService depositLimitService,
            LogService logService,
            EventService eventService

            )
        {
            _setDepositLimitTransaction = setDepositLimitTransaction;
            _depositLimitService = depositLimitService;
            _logService = logService;
            _eventService = eventService;
        }

        public async Task Handle(SetDepositLimit setDepositLimit)
        {
            //Begin transaction
            _setDepositLimitTransaction.Begin();

            //Set deposit limit
            var depositLimit = await _depositLimitService.Set(setDepositLimit.ToDepositLimit());

            //Add log entry
            var log = depositLimit.ToLog();
            await _logService.Add(log);

            //Add events
            await _eventService.Add(depositLimit.Events);

            //Commit                
            _setDepositLimitTransaction.Commit();

            //Log
            _log.Info(setDepositLimit.SerializeAsKeyValues());
        }
    }
}
