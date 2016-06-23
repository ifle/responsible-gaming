using System.Data.Entity;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Events;
using Pinnacle.ResponsibleGaming.Domain.Contexts;


namespace Pinnacle.ResponsibleGaming.Application.Contexts
{ 
    public abstract class Context
    {
        private readonly MainContext _mainDbContext;
        private DbContextTransaction _contextTransaction;


        public Context(MainContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public void BeginTransaction()
        {
            _contextTransaction = _mainDbContext.Database.BeginTransaction();
        }
        public void Commit()
        {
            _contextTransaction.Commit();
        }

        public Task<int> SaveChangesAsync(CustomerEvent customerEvent)
        {
            return _mainDbContext.SaveChangesAsync(customerEvent);
        }
    }
}
