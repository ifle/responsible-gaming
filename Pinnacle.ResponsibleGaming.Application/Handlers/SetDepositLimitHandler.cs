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
    public class SetDepositLimitHandler
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DbContext _dbContext;
        private readonly DepositLimitQuery _depositLimitQuery;
        private readonly Bus.Bus _bus;

        public SetDepositLimitHandler(
            DbContext dbContext,
            DepositLimitQuery depositLimitQuery,
            Bus.Bus bus

            )
        {
            _dbContext = dbContext;
            _depositLimitQuery = depositLimitQuery;
            _bus = bus;
        }

        public async Task<bool> Handle(SetDepositLimit setDepositLimit)
        {
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                //Event 
                var depositLimitSet = setDepositLimit.ToDepositLimitSet();
                var @event = new Event(depositLimitSet);
                _dbContext.Set<Event>().Add(@event);

                //State
                var depositLimit = await _depositLimitQuery.GetByCustomerId(setDepositLimit.CustomerId);
                if (depositLimit != null)
                {
                    depositLimit.Apply(depositLimitSet);
                }
                else
                {
                    depositLimit = new DepositLimit();
                    depositLimit.Apply(depositLimitSet);
                }
                _dbContext.Set<Limit>().AddOrUpdate(depositLimit);

                //Publish (to remove)
                await _bus.Publish(depositLimitSet);

                //Commit
                await _dbContext.SaveChangesAsync();
                dbContextTransaction.Commit();
            }
            _log.Info(setDepositLimit.SerializeAsKeyValues());

            return true;
        }
    }
}
