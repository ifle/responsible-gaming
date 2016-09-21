using System.Data.Entity;
using System.Data.Entity.Migrations;
<<<<<<< HEAD
using System.Linq;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Expressions;
using Pinnacle.ResponsibleGaming.Domain.Entities;
=======
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Expressions;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Domain.Repositories;
>>>>>>> feature/with_messaging
using Pinnacle.ResponsibleGaming.Infrastructure.Contexts;

namespace Pinnacle.ResponsibleGaming.Infrastructure.Repositories
{
<<<<<<< HEAD
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
=======
    public class LimitRepository : ILimitRepository
    {
        private readonly ResponsibleGamingContext _context;

        public LimitRepository(ResponsibleGamingContext context)
        {
            _context = context;
        }
        public async Task<Limit> Get(string customerId, LimitType limitType)
        {
            return await _context.Limits.FirstOrDefaultAsync(LimitExpressions.IsActive(customerId, limitType));
        }

        public void AddOrUpdate(Limit limit)
        {
            _context.Limits.AddOrUpdate(limit);
>>>>>>> feature/with_messaging
        }
    }
}
