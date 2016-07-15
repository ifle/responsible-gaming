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
    public class SetDepositLimitHandler
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IContext _context;
        private readonly DepositLimitService _depositLimitService;
        private readonly LogService _logService;
        private readonly EventService _eventService;

        public SetDepositLimitHandler(
            IContext context,
            DepositLimitService depositLimitService,
            LogService logService,
            EventService eventService

            )
        {
            _context = context;
            _depositLimitService = depositLimitService;
            _logService = logService;
            _eventService = eventService;
        }

        public async Task Handle(SetDepositLimit setDepositLimit)
        {
            //Begin transaction
            _context.BeginTransaction();

            //Set deposit limit
            var depositLimit = setDepositLimit.ToDepositLimit();
            depositLimit = await _depositLimitService.Set(depositLimit);

            //Add log
            var log = new Log(depositLimit);
            await _logService.Add(log);

            //Add event
            var @event = new Event(new LimitSet(depositLimit));
            await _eventService.Add(@event);

            //Commit                
            _context.Commit();

            //Log
            _log.Info(setDepositLimit.SerializeAsKeyValues());
        }
    }
}
