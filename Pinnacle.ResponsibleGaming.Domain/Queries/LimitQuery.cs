using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Expressions;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Domain.Queries
{
    public static class LimitQuery
    {
        public static async Task<T> GetByCustomerId<T>(this DbSet<Limit> t, string customerId) where T:Limit
        {
            return await t.OfType<T>().FirstOrDefaultAsync(x => x.CustomerId == customerId);
        }
        public static async Task<T> GetCurrentActive<T>(this DbSet<Limit> t, string customerId) where T : Limit
        {
            return await t.OfType<T>().FirstOrDefaultAsync(LimitExpressions.CurrentActiveCustomerLimit<T>(customerId));
        }
    }
}
