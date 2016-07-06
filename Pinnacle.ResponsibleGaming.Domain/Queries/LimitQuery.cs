using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Expressions;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Domain.Queries
{
    public abstract class LimitQuery<T> where T : Limit
    {
        private readonly DbContext _dbContext;

        public LimitQuery(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> GetByCustomerId(string customerId)
        {
            return await _dbContext.Set<Limit>().OfType<T>().FirstOrDefaultAsync(x => x.CustomerId == customerId);
        }
        public async Task<T> GetCurrentActiveAsync(string customerId)
        {
            return await _dbContext.Set<Limit>().OfType<T>().FirstOrDefaultAsync(LimitExpressions.IsActiveCustomerLimit<T>(customerId));
        }
    }
}
