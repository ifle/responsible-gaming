


namespace Pinnacle.ResponsibleGaming.Domain.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public string Limit { get; set; }
        public string CustomerId { get; set; }
        public string PeriodInDays { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Author { get; set; }
        public string CreationTime { get; set; }
    }
}
