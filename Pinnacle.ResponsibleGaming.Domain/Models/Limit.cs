using System;
using Pinnacle.ResponsibleGaming.Domain.Expressions;

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
                if (LimitExpressions.IsActiveLimit<Limit>().Compile()(this))
                    return LimitStatus.Active;
                return LimitStatus.Expired;
            }
        }
    }
}
