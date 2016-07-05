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
        private readonly MainContext _mainContext;

        public LimitQuery(MainContext mainContext)
        {
            _mainContext = mainContext;
        }
        public async Task<T> GetByCustomerId(string customerId)
        {
            return await _mainContext.Limits.OfType<T>().FirstOrDefaultAsync(x => x.CustomerId == customerId);
        }
        public async Task<T> GetCurrentActiveAsync(string customerId)
        {
            return await _mainContext.Limits.OfType<T>().FirstOrDefaultAsync(LimitExpressions.IsActiveCustomerLimit<T>(customerId));
        }
    }
}
