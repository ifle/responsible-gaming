using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.Domain.Services
{
    public class EventService
    {
        private readonly DbContext _dbContext;

        public EventService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddEvents(List<Event> events)
        {
            _dbContext.Set<Event>().AddRange(events);
            await _dbContext.SaveChangesAsync();
        }
    }
}
