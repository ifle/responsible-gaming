using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Domain.Expressions;

namespace Pinnacle.ResponsibleGaming.Domain.Repositories
{
    public class DepositLimitRepository: LimitRepository<DepositLimit>
    {
        public DepositLimitRepository(DbContext dbContext)
            :base(dbContext)
        {
        }
    }
}
