using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Contexts;
using Pinnacle.ResponsibleGaming.Domain.Expressions;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Domain.Queries
{
    public abstract class LimitQuery<T> where T : Limit
    {
        private readonly MainContext _mainDbContext;

        public LimitQuery(MainContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }
        public async Task<T> GetByCustomerId(string customerId)
        {
            return await _mainDbContext.Limits.OfType<T>().FirstOrDefaultAsync(x => x.CustomerId == customerId);
        }
        public async Task<T> GetCurrentActive(string customerId)
        {
            return await _mainDbContext.Limits.OfType<T>().FirstOrDefaultAsync(LimitExpressions.CurrentActiveLimit<T>(customerId));
        }
    }
}
