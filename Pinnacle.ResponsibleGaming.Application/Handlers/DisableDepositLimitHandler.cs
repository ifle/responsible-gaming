using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Application.Contexts;
using Pinnacle.ResponsibleGaming.Application._Framework.Extensions;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Domain.Services;

namespace Pinnacle.ResponsibleGaming.Application.Handlers
{
    public class DisableDepositLimitHandler
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private IDisableDepositLimitContext _disableDepositLimitContext;
        private readonly DepositLimitService _depositLimitService;
        private readonly LogService _logService;

        public DisableDepositLimitHandler(
           IDisableDepositLimitContext disableDepositLimitContext,
            DepositLimitService depositLimitService,
            LogService logService

            )
        {
            _disableDepositLimitContext = disableDepositLimitContext;
            _depositLimitService = depositLimitService;
            _logService = logService;
        }

        public async Task Handle(DisableDepositLimit disableDepositLimit)
        {
            //Begin transaction
            _disableDepositLimitContext.BeginTransaction();

            //Disable deposit limit
            var depositLimit = await _depositLimitService.Disable(
                    disableDepositLimit.CustomerId,
                    disableDepositLimit.Author
                    );

            //Add log entry
            var log = new Log(depositLimit);
            await _logService.Add(log);

            //Commit                
            _disableDepositLimitContext.Commit();

            //Log
            _log.Info(disableDepositLimit.SerializeAsKeyValues());
        }
    }
}
