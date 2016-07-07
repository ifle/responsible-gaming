using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Application._Common.Extensions;
using Pinnacle.ResponsibleGaming.Domain.Models;
using Pinnacle.ResponsibleGaming.Domain.Queries;

namespace Pinnacle.ResponsibleGaming.Application.Handlers
{
    public class SetDepositLimitHandler
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DbContext _dbContext;
        private readonly DepositLimitQuery _depositLimitQuery;

        public SetDepositLimitHandler(
            DbContext dbContext,
            DepositLimitQuery depositLimitQuery

            )
        {
            _dbContext = dbContext;
            _depositLimitQuery = depositLimitQuery;
        }

        public async Task<bool> Handle(SetDepositLimit setDepositLimit)
        {
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                //Limit
                var depositLimit = await _depositLimitQuery.GetByCustomerId(setDepositLimit.CustomerId);
                if (depositLimit != null)
                {
                    depositLimit.Modify(setDepositLimit.Amount, depositLimit.PeriodInDays, depositLimit.StartDate, depositLimit.EndDate, depositLimit.Author);
                }
                else
                {
                    depositLimit = setDepositLimit.ToDepositLimit();
                }
                _dbContext.Set<Limit>().AddOrUpdate(depositLimit);
                await _dbContext.SaveChangesAsync();

                //Log 
                _dbContext.Set<Log>().Add(depositLimit.ToLog());
                await _dbContext.SaveChangesAsync();

                //Commit                
                dbContextTransaction.Commit();
            }
            _log.Info(setDepositLimit.SerializeAsKeyValues());

            return true;
        }
    }
}
