using System;
using System.Collections.Generic;

namespace Pinnacle.ResponsibleGaming.Domain.Entities
{
    public abstract class Entity
    {
        public List<Event> Events { get; }

        protected Entity()
        {
            Events = new List<Event>();
        }

        public void AddEvent(object @event)
        {
            Events.Add(new Event(@event));
        }
    }
}
