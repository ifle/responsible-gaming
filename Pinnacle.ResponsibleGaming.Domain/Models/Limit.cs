using System;

namespace Pinnacle.ResponsibleGaming.Domain.Models
{
    public abstract class Limit
    {
        public string CustomerId { get; set; }
        public int? PeriodInDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public LimitStatus Status
        {
            get
            {
                var now = DateTime.Now;
                if (StartDate < now && (!EndDate.HasValue || EndDate.Value > now))
                    return LimitStatus.Active;
                return LimitStatus.Expired;
            }
        }
        public string Author { get; set; }
        public DateTime CreationTime { get; set; }

       
    }
}
