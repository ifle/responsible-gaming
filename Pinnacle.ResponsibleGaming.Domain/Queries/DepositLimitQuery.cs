using Pinnacle.ResponsibleGaming.Domain.Contexts;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Domain.Queries
{
    public class DepositLimitQuery: LimitQuery<DepositLimit>
    {
        public DepositLimitQuery(MainContext mainDbContext)
            :base(mainDbContext)
        {
        }
    }
}
