using System;
using Newtonsoft.Json;

namespace Pinnacle.ResponsibleGaming.Domain.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Json { get; set; }
        public bool Sent { get; set; }

        public Event(object @event)
        {
            Name = @event.GetType().Name;
            Json = JsonConvert.SerializeObject(@event);
        }

    }
}
