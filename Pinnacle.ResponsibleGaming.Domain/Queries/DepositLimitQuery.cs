using System.Data.Entity;
using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.Domain.Queries
{
    public class DepositLimitQuery: LimitQuery<DepositLimit>
    {
        public DepositLimitQuery(DbContext dbContext)
            :base(dbContext)
        {
        }
    }
}
