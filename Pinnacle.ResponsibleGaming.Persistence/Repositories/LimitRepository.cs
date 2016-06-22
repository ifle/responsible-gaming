using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Expressions;
using Pinnacle.ResponsibleGaming.Domain.Models;
using Pinnacle.ResponsibleGaming.Domain.Repositories;
using Pinnacle.ResponsibleGaming.Persistence.Contexts;


namespace Pinnacle.ResponsibleGaming.Persistence.Repositories
{
    public abstract class LimitRepository<T>: Repository<T>, ILimitRepository<T> where T : Limit
    {
        private readonly MainContext _mainDbContext;

        public LimitRepository(MainContext mainDbContext):base(mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task<Limit> GetCurrentActiveCustomerLimit(string customerId)
        {
            return await _mainDbContext.Limits.OfType<T>().FirstOrDefaultAsync(LimitExpressions.CurrentActiveCustomerLimit(customerId));
        }
    }
}
