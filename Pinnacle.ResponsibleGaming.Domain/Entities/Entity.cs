using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Pinnacle.ResponsibleGaming.Domain.Entities
{
    public class Entity
    {
        [NotMapped]
        public List<Event> Events { get; set; }

        public Entity()
        {
            Events = new List<Event>();
        }
    }
}
