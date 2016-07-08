using System.Collections.Generic;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Domain.Repositories;

namespace Pinnacle.ResponsibleGaming.Domain.Services
{
    public class EventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task Add(List<Event> events)
        {
           await _eventRepository.Insert(events);
        }
    }
}
