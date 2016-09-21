using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Expressions;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Domain.Repositories;
using Pinnacle.ResponsibleGaming.Infrastructure.Contexts;

namespace Pinnacle.ResponsibleGaming.Infrastructure.Repositories
{
    public class LimitRepository : ILimitRepository
    {
        private readonly MainContext _context;

        public LimitRepository(MainContext context)
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
        }
    }
}
