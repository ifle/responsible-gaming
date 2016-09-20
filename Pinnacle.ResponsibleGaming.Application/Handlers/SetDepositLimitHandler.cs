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
        private readonly DepositLimitService _depositLimitService;

        public SetDepositLimitHandler(
            DbContext context,
            DepositLimitService depositLimitService
            )
        {
            _context = context;
            _depositLimitService = depositLimitService;
        }

        public async Task Handle(SetDepositLimit setDepositLimit)
        {
            //Set deposit limit
            var depositLimit = setDepositLimit.ToDepositLimit();
            await _depositLimitService.Set(depositLimit);

            //Save changes
            await _context.SaveChangesAsync();

            //Log deposit limit into Splunk
            _log.Info(setDepositLimit.SerializeAsKeyValues());
        }
    }
}
