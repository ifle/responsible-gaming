using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.Domain.Repositories
{
    public class EventRepository
    {
        private readonly DbContext _dbContext;

        public EventRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Insert(List<Event> events)
        {
            _dbContext.Set<Event>().AddRange(events);
            await _dbContext.SaveChangesAsync();
        }
    }
}
