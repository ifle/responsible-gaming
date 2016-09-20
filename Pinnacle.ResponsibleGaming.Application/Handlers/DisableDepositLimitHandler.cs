using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Application._Framework.Extensions;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Domain.Services;
using System.Data.Entity;


namespace Pinnacle.ResponsibleGaming.Application.Handlers
{
    public class DisableDepositLimitHandler
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DbContext _context;
        private readonly DepositLimitService _depositLimitService;
        private readonly EventService _eventService;

        public DisableDepositLimitHandler(
           DbContext context,
           DepositLimitService depositLimitService,
           EventService eventService

            )
        {
            _context = context;
            _depositLimitService = depositLimitService;
            _eventService = eventService;
        }

        public async Task Handle(DisableDepositLimit disableDepositLimit)
        {
            //Begin transaction
            using (var transaction = _context.Database.BeginTransaction())
            {
                //Disable deposit limit
                var depositLimit = await _depositLimitService.Disable(disableDepositLimit.CustomerId, disableDepositLimit.Author);

                //Add events
                foreach (var @event in depositLimit.Events)
                {
                    await _eventService.Add(@event);
                }

                //Save changes
                await _context.SaveChangesAsync();

                //Commit                
                transaction.Commit();
            }

            //Log
            _log.Info(disableDepositLimit.SerializeAsKeyValues());
        }
    }
}
