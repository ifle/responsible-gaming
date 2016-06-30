using System;

namespace Pinnacle.ResponsibleGaming.Read.Views
{
    public class Log
    {
        public string CustomerId { get; set; }
        public string Action { get; set; }
        public decimal Limit { get; set; }
        public int? PeriodInDays { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Author { get; set; }
        public DateTime CreationTime { get; set; }

    }
}
