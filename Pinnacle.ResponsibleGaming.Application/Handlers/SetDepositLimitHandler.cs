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
    public class SetDepositLimitHandler
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DbContext _context;
        private readonly DepositLimitService _depositLimitService;
        private readonly EventService _eventService;

        public SetDepositLimitHandler(
            DbContext context,
            DepositLimitService depositLimitService,
            EventService eventService

            )
        {
            _context = context;
            _depositLimitService = depositLimitService;
            _eventService = eventService;
        }

        public async Task Handle(SetDepositLimit setDepositLimit)
        {
            //Begin transaction
            using (var transaction = _context.Database.BeginTransaction())
            {
                //Set deposit limit
                var depositLimit = setDepositLimit.ToDepositLimit();
                depositLimit = await _depositLimitService.Set(depositLimit);               

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

            //Log deposit limit into Splunk
            _log.Info(setDepositLimit.SerializeAsKeyValues());
        }
    }
}
