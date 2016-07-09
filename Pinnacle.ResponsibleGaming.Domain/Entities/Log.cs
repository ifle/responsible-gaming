using System;



namespace Pinnacle.ResponsibleGaming.Domain.Entities
{
    public class Log
    {
        public int LogId { get; set; }
        public int LimitId { get; set; }
        public string CustomerId { get; set; }
        public int LimitTypeId { get; set; }
        public decimal Limit { get; set; }
        public int? PeriodInDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Author { get; set; }
        public DateTime ModificationTime { get; set; }
    }
}
