﻿using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Domain.Repositories;
using Pinnacle.ResponsibleGaming.Infrastructure.Contexts;

namespace Pinnacle.ResponsibleGaming.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly Context _context;

        public EventRepository(Context context)
        {
            _context = context;
        }

        public void Add(Event @event)
        {
            _context.Events.Add(@event);
        }
    }
}
