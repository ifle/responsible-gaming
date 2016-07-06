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
    public class DisableDepositLimitHandler
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DbContext _dbContext;
        private readonly DepositLimitQuery _depositLimitQuery;

        public DisableDepositLimitHandler(
            DbContext dbContext,
            DepositLimitQuery depositLimitQuery

            )
        {
            _dbContext = dbContext;
            _depositLimitQuery = depositLimitQuery;
        }

        public async Task<bool> Handle(DisableDepositLimit disableDepositLimit)
        {
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                //Limit
                var depositLimit = await _depositLimitQuery.GetByCustomerId(disableDepositLimit.CustomerId);
                if(depositLimit == null) return false;
                depositLimit.Disable(disableDepositLimit.Author, disableDepositLimit.CreationTime);
                _dbContext.Set<Limit>().AddOrUpdate(depositLimit);

                //Log 
                _dbContext.Set<Log>().Add(depositLimit.ToLog());

                //Commit
                await _dbContext.SaveChangesAsync();
                dbContextTransaction.Commit();
            }
            _log.Info(disableDepositLimit.SerializeAsKeyValues());

            return true;
        }
    }
}
