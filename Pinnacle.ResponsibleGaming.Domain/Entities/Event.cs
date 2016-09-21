using Newtonsoft.Json;
using Pinnacle.ResponsibleGaming.Events;


namespace Pinnacle.ResponsibleGaming.Domain.Entities
{
    public class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Json { get; set; }
        public bool Sent { get; set; }

        public Event() { }

        public Event(object @event)
        {

            Name = @event.GetType().Name;
            Json = JsonConvert.SerializeObject(@event,
                            Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            });
            Sent = false;
        }

        public LimitSet ToLimitSet()
        {
            return JsonConvert.DeserializeObject<LimitSet>(Json);
        }
    }
}
