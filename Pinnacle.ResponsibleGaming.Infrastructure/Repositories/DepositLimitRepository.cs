using Pinnacle.ResponsibleGaming.Domain.Models;
using Pinnacle.ResponsibleGaming.Domain.Repositories;
using Pinnacle.ResponsibleGaming.Infrastructure.Contexts;

namespace Pinnacle.ResponsibleGaming.Infrastructure.Repositories
{
    public class DepositLimitRepository: LimitRepository<DepositLimit>, IDepositLimitRepository
    {
        public DepositLimitRepository(Context context)
            :base(context)
        {
        }
    }
}
