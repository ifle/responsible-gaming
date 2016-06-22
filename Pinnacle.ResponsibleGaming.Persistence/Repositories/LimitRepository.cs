using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Expressions;
using Pinnacle.ResponsibleGaming.Domain.Models;
using Pinnacle.ResponsibleGaming.Domain.Repositories;
using Pinnacle.ResponsibleGaming.Persistence.Contexts;


namespace Pinnacle.ResponsibleGaming.Persistence.Repositories
{
    public abstract class LimitRepository<T>:  ILimitRepository<T> where T : Limit
    {
        private readonly MainContext _mainDbContext;

        public LimitRepository(MainContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task<T> GetByCustomerId(string customerId)
        {
            return await _mainDbContext.Limits.OfType<T>().FirstOrDefaultAsync(x=>x.CustomerId == customerId);
        }
        public async Task<T> GetCurrentActive(string customerId)
        {
            return await _mainDbContext.Limits.OfType<T>().FirstOrDefaultAsync(LimitExpressions.CurrentActiveCustomerLimit(customerId)) as T;
        }

        public void AddOrUpdate(T t)
        {
            _mainDbContext.Limits.AddOrUpdate(t);
        }
    }
}
