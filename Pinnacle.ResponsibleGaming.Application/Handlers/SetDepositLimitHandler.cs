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
    public class SetDepositLimitHandler
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly MainContext _mainContext;
        private readonly DepositLimitQuery _depositLimitQuery;

        public SetDepositLimitHandler(
            MainContext mainContext,
            DepositLimitQuery depositLimitQuery

            )
        {
            _mainContext = mainContext;
            _depositLimitQuery = depositLimitQuery;
        }

        public async Task<bool> Handle(SetDepositLimit setDepositLimit)
        {
            using (var dbContextTransaction = _mainContext.Database.BeginTransaction())
            {
                //Limit
                var depositLimit = await _depositLimitQuery.GetByCustomerId(setDepositLimit.CustomerId);
                if (depositLimit != null)
                {
                    depositLimit.ApplyNewLimit(setDepositLimit.ToDepositLimit());
                }
                else
                {
                    depositLimit = setDepositLimit.ToDepositLimit();
                }
                _mainContext.Limits.AddOrUpdate(depositLimit);

                //Log 
                _mainContext.Logs.Add(setDepositLimit.ToLog());

                //Commit
                await _mainContext.SaveChangesAsync();
                dbContextTransaction.Commit();
            }
            _log.Info(setDepositLimit.SerializeAsKeyValues());

            return true;
        }
    }
}
