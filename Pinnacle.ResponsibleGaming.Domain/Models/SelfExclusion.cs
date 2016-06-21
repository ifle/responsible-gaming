

namespace Pinnacle.ResponsibleGaming.Domain.Models
{
    public class SelfExclusion : Limit
    {
        public int TimeInDays { get; set; }

        public Log ToLog(string action)
        {
            return new Log
            {
                Action = action,
                CustomerId = CustomerId,
                Value = TimeInDays,
                PeriodInDays = PeriodInDays,
                StartDate = StartDate,
                EndDate = EndDate,
                Author = Author,
                CreationTime = CreationTime
            };
        }
    }
}
