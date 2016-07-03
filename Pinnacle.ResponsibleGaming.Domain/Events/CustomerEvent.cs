

namespace Pinnacle.ResponsibleGaming.Domain.Events
{
 
    public abstract class CustomerEvent: Event
    {
        public string CustomerId { get; set; }
    }
}
