using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Expressions;
using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.Domain.Repositories
{
    public abstract class LimitRepository<T> where T : Limit
    {
        private readonly DbContext _dbContext;

        protected LimitRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> GetActiveByCustomerId(string customerId)
        {
            return await _dbContext.Set<Limit>().OfType<T>().FirstOrDefaultAsync(LimitExpressions.IsActiveLimit<T>(customerId));
        }

        public async Task Upsert(T t)
        {
            _dbContext.Set<T>().AddOrUpdate(t);
            await _dbContext.SaveChangesAsync();
        }
    }
}
