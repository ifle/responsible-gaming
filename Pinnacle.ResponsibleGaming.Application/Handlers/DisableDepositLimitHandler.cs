using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Application._Common.Extensions;
using Pinnacle.ResponsibleGaming.Domain.Models;
using Pinnacle.ResponsibleGaming.Domain.Queries;
using Pinnacle.ResponsibleGaming.Read.Updaters;

namespace Pinnacle.ResponsibleGaming.Application.Handlers
{
    public class DisableDepositLimitHandler
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DbContext _dbContext;
        private readonly DepositLimitQuery _depositLimitQuery;
        private readonly Bus.Bus _bus;

        public DisableDepositLimitHandler(
            DbContext dbContext,
            DepositLimitQuery depositLimitQuery,
            Bus.Bus bus

            )
        {
            _dbContext = dbContext;
            _depositLimitQuery = depositLimitQuery;
            _bus = bus;
        }

        public async Task<bool> Handle(DisableDepositLimit disableDepositLimit)
        {
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                var depositLimit = await _depositLimitQuery.GetByCustomerId(disableDepositLimit.CustomerId);
                if (depositLimit == null) return false;

                //Event 
                var depositLimitDisabled = disableDepositLimit.ToDepositLimitDisabled();
                var @event = new Event(depositLimitDisabled);
                _dbContext.Set<Event>().Add(@event);

                //State
                depositLimit.Apply(depositLimitDisabled); 
                _dbContext.Set<Limit>().AddOrUpdate(depositLimit);

                //await _logUpdater.Update(depositLimitSet);
                await _bus.Publish(depositLimitDisabled);// this is temporary sa we cannot publish event without ensuring the commit

                //Save
                await _dbContext.SaveChangesAsync();

                //Commit
                dbContextTransaction.Commit();
            }
            _log.Info(disableDepositLimit.SerializeAsKeyValues());
            return true;
        }
    }
}
