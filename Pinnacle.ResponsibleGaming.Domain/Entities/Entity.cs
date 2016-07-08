using System.Collections.Generic;
using Newtonsoft.Json;


namespace Pinnacle.ResponsibleGaming.Domain.Entities
{
    public class Entity
    {
        [JsonIgnore]
        public List<Event> Events { get; set; }

        public Entity()
        {
            Events = new List<Event>();
        }
    }
}
