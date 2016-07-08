using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Pinnacle.ResponsibleGaming.Application._Common.Extensions;
using Pinnacle.ResponsibleGaming.Domain.Services;

namespace Pinnacle.ResponsibleGaming.Application.DisableDepositLimit
{
    public class Handler
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private IContext _context;
        private readonly DepositLimitService _depositLimitService;
        private readonly LogService _logService;

        public Handler(
           IContext context,
            DepositLimitService depositLimitService,
            LogService logService

            )
        {
            _context = context;
            _depositLimitService = depositLimitService;
            _logService = logService;
        }

        public async Task Handle(Request request)
        {
            //Begin transaction
            _context.BeginTransaction();

            //Disable deposit limit
            var depositLimit = await _depositLimitService.Disable(
                    request.CustomerId,
                    request.Author
                    );

            //Add log entry
            var log = depositLimit.ToLog();
            await _logService.Add(log);

            //Commit                
            _context.Commit();

            //Log
            _log.Info(request.SerializeAsKeyValues());
        }
    }
}
