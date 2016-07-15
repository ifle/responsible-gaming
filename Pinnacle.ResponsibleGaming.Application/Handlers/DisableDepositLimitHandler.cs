using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Application.Contexts;
using Pinnacle.ResponsibleGaming.Application._Framework.Extensions;
using Pinnacle.ResponsibleGaming.Domain.Models;
using Pinnacle.ResponsibleGaming.Domain.Services;

namespace Pinnacle.ResponsibleGaming.Application.Handlers
{
    public class DisableDepositLimitHandler
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IContext _context;
        private readonly DepositLimitService _depositLimitService;
        private readonly LogService _logService;

        public DisableDepositLimitHandler(
           IContext context,
           DepositLimitService depositLimitService,
           LogService logService

            )
        {
            _context = context;
            _depositLimitService = depositLimitService;
            _logService = logService;
        }

        public async Task Handle(DisableDepositLimit disableDepositLimit)
        {
            //Begin transaction
            _context.BeginTransaction();

            //Disable deposit limit
            var depositLimit = await _depositLimitService.Disable(disableDepositLimit.CustomerId,disableDepositLimit.Author);

            //Add log
            var log = new Log(depositLimit);
            await _logService.Add(log);

            //Commit                
            _context.Commit();

            //Log
            _log.Info(disableDepositLimit.SerializeAsKeyValues());
        }
    }
}
