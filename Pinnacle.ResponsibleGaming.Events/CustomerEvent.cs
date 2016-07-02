

namespace Pinnacle.ResponsibleGaming.Events
{
 
    public abstract class CustomerEvent: Event
    {
        public string CustomerId { get; set; }
    }
}
