using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Expressions;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Infrastructure.Contexts;

namespace Pinnacle.ResponsibleGaming.Infrastructure.Repositories
{
    public abstract class LimitRepository<T> where T : Limit
    {
        private readonly Context _context;

        protected LimitRepository(Context context)
        {
            _context = context;
        }
        public async Task<T> GetActiveByCustomerId(string customerId)
        {
            return await _context.Set<Limit>().OfType<T>().FirstOrDefaultAsync(LimitExpressions.IsActiveLimit<T>(customerId));
        }

        public void AddOrUpdate(T t)
        {
            _context.Limits.AddOrUpdate(t);
        }
    }
}
