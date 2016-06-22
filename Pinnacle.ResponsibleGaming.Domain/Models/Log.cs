using System;

namespace Pinnacle.ResponsibleGaming.Domain.Models
{
    public class Log
    {
        public string CustomerId { get; set; }
        public string Action { get; set; }
        public int? Limit { get; set; }
        public int? PeriodInDays { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Author { get; set; }
        public DateTime CreationTime { get; set; }

    }
}
