using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Pinnacle.ResponsibleGaming.Application._Common.Extensions;
using Pinnacle.ResponsibleGaming.Domain.Services;

namespace Pinnacle.ResponsibleGaming.Application.SetDepositLimit
{
    public class Handler
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IContext _context;
        private readonly DepositLimitService _depositLimitService;
        private readonly LogService _logService;
        private readonly EventService _eventService;

        public Handler(
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

        public async Task Handle(Request request)
        {
            //Begin transaction
            _context.BeginTransaction();

            //Set deposit limit
            var depositLimit = await _depositLimitService.Set(request.ToDepositLimit());

            //Add log entry
            var log = depositLimit.ToLog();
            await _logService.Add(log);

            //Add events
            await _eventService.Add(depositLimit.Events);

            //Commit                
            _context.Commit();

            //Log
            _log.Info(request.SerializeAsKeyValues());
        }
    }
}
