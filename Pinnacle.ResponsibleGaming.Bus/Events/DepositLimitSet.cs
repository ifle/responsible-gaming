using System;

namespace Pinnacle.ResponsibleGaming.Bus.Events
{
    public class DepositLimitSet: CustomerEvent
    {
        public decimal Amount { get; set; }
        public int? PeriodInDays { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Author { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
