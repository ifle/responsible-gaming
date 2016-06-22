using Pinnacle.ResponsibleGaming.Domain.Models;
using Pinnacle.ResponsibleGaming.Domain.Repositories;
using Pinnacle.ResponsibleGaming.Persistence.Contexts;


namespace Pinnacle.ResponsibleGaming.Persistence.Repositories
{
    public class DepositLimitRepository: LimitRepository<DepositLimit>, IDepositLimitRepository
    {
        public DepositLimitRepository(MainContext mainDbContext)
            :base(mainDbContext)
        {
        }
    }
}
