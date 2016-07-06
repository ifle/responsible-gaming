using System;



namespace Pinnacle.ResponsibleGaming.Domain.Models
{
    public class Log
    {
        public int LogId { get; set; }
        public string CustomerId { get; set; }
        public int LimitTypeId { get; set; }
        public decimal Limit { get; set; }
        public int? PeriodInDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Author { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
