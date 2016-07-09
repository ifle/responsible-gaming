using System.Data.Entity;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Domain.Repositories;

namespace Pinnacle.ResponsibleGaming.Infrastructure.Repositories
{
    public class DepositLimitRepository: LimitRepository<DepositLimit>, IDepositLimitRepository
    {
        public DepositLimitRepository(DbContext dbContext)
            :base(dbContext)
        {
        }
    }
}
