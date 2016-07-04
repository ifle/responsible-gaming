using System.Data.Entity.Migrations;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Application._Common.Extensions;
using Pinnacle.ResponsibleGaming.Domain.Contexts;
using Pinnacle.ResponsibleGaming.Domain.Models;
using Pinnacle.ResponsibleGaming.Domain.Queries;

namespace Pinnacle.ResponsibleGaming.Application.Handlers
{
    public class DisableDepositLimitHandler
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly MainContext _mainContext;
        private readonly DepositLimitQuery _depositLimitQuery;

        public DisableDepositLimitHandler(
            MainContext mainContext,
            DepositLimitQuery depositLimitQuery

            )
        {
            _mainContext = mainContext;
            _depositLimitQuery = depositLimitQuery;
        }

        public async Task<bool> Handle(DisableDepositLimit disableDepositLimit)
        {
            using (var dbContextTransaction = _mainContext.Database.BeginTransaction())
            {
                //Limit
                var depositLimit = await _depositLimitQuery.GetByCustomerId(disableDepositLimit.CustomerId);
                if(depositLimit == null) return false;
                depositLimit.Disable(disableDepositLimit.Author, disableDepositLimit.CreationTime);
                _mainContext.Limits.AddOrUpdate(depositLimit);

                //Log 
                _mainContext.Logs.Add(disableDepositLimit.ToLog());

                //Commit
                await _mainContext.SaveChangesAsync();
                dbContextTransaction.Commit();
            }
            _log.Info(disableDepositLimit.SerializeAsKeyValues());

            return true;
        }
    }
}
