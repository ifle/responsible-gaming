using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Application._Framework.Extensions;
using Pinnacle.ResponsibleGaming.Domain.Services;
using System.Data.Entity;

namespace Pinnacle.ResponsibleGaming.Application.Handlers
{
    public class SetDepositLimitHandler
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DbContext _context;
        private readonly LimitService _limitService;

        public SetDepositLimitHandler(
            DbContext context,
            LimitService limitService
            )
        {
            _context = context;
            _limitService = limitService;
        }

        public async Task Handle(SetDepositLimit setDepositLimit)
        {
            //Set deposit limit
            var limit = setDepositLimit.ToLimit();
            await _limitService.Set(limit);

            //Save changes
            await _context.SaveChangesAsync();

            //Log deposit limit into Splunk
            _log.Info(setDepositLimit.SerializeAsKeyValues());
        }
    }
}
