using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Application.Contexts;
using Pinnacle.ResponsibleGaming.Application._Framework.Extensions;
using Pinnacle.ResponsibleGaming.Domain.Models;
using Pinnacle.ResponsibleGaming.Domain.Services;
using Pinnacle.ResponsibleGaming.Events;

namespace Pinnacle.ResponsibleGaming.Application.Handlers
{
    public class DisableDepositLimitHandler
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private IDisableDepositLimitContext _disableDepositLimitContext;
        private readonly DepositLimitService _depositLimitService;
        private readonly LogService _logService;
        private readonly EventService _eventService;

        public DisableDepositLimitHandler(
           IDisableDepositLimitContext disableDepositLimitContext,
           DepositLimitService depositLimitService,
           LogService logService,
           EventService eventService

            )
        {
            _disableDepositLimitContext = disableDepositLimitContext;
            _depositLimitService = depositLimitService;
            _logService = logService;
            _eventService = eventService;
        }

        public async Task Handle(DisableDepositLimit disableDepositLimit)
        {
            //Begin transaction
            _disableDepositLimitContext.BeginTransaction();

            //Disable deposit limit
            var depositLimit = await _depositLimitService.Disable(disableDepositLimit.CustomerId,disableDepositLimit.Author);

            //Add log entry
            var log = new Log(depositLimit);
            await _logService.Add(log);

            //Add event
            var @event = new Event(new LimitSet(depositLimit));
            await _eventService.Add(@event);

            //Commit                
            _disableDepositLimitContext.Commit();

            //Log
            _log.Info(disableDepositLimit.SerializeAsKeyValues());
        }
    }
}
