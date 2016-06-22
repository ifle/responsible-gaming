using System.Data.Entity.Migrations;
using Pinnacle.ResponsibleGaming.Domain.Models;
using Pinnacle.ResponsibleGaming.Persistence.Contexts;

namespace Pinnacle.ResponsibleGaming.Persistence.Repositories
{
    public abstract class Repository<T> where T : Limit
    {
        private readonly MainContext _mainDbContext;

        public Repository(MainContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public void AddOrUpdate(T t)
        {
            _mainDbContext.Limits.AddOrUpdate(t);
        }
    }
}
