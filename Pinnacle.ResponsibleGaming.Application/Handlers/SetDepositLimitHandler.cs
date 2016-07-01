using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Application._Common.Extensions;
using Pinnacle.ResponsibleGaming.Bus.Events;
using Pinnacle.ResponsibleGaming.Domain.Models;
using Pinnacle.ResponsibleGaming.Domain.Validators;
using Pinnacle.ResponsibleGaming.Read.Updaters;

namespace Pinnacle.ResponsibleGaming.Application.Handlers
{
    public class SetDepositLimitHandler
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DepositLimitValidator _depositLimitValidator;
        private readonly DbContext _dbContext;
        private readonly LogUpdater _logUpdater;

        public SetDepositLimitHandler(
            DepositLimitValidator depositLimitValidator,
            DbContext dbContext,
            LogUpdater logUpdater

            )
        {
            _depositLimitValidator = depositLimitValidator;
            _dbContext = dbContext;
            _logUpdater = logUpdater;
        }

        public async Task Handle(SetDepositLimit setDepositLimit)
        {
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                //Validate
                var depositLimit = setDepositLimit.ToDepositLimit();
                await _depositLimitValidator.Validate(depositLimit);

                //Add deposit limit or modify existing      
                _dbContext.Set<Limit>().AddOrUpdate(depositLimit);

                //Save event (the event gets stored under the same transaction) 
                var depositLimitSet = setDepositLimit.ToDepositLimitSet(); 
                var @event = new Event(depositLimitSet);
                _dbContext.Set<Event>().Add(@event);

                //Once implemented the bus, the following line will be replaced by bus.Send()
                await _logUpdater.Update(depositLimitSet);

                //Save
                await _dbContext.SaveChangesAsync();

                //Commit
                dbContextTransaction.Commit();
            }
            _log.Info(setDepositLimit.SerializeAsKeyValues()); 
        }
    }
}
