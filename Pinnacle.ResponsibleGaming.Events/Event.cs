

using System;

namespace Pinnacle.ResponsibleGaming.Events
{
 
    public abstract class Event
    {
        public Guid EventId { get; set; }

        public Event()
        {
            EventId = Guid.NewGuid();
        }
    }
}
