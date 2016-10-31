using System;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Events;

namespace Pinnacle.ResponsibleGaming.Domain.Builders
{
    public static class LimitBuilders
    {
        public static LimitSet Build(this LimitSet limitSet, Limit limit)
        {
            return new LimitSet
            {
                CustomerId = limit.CustomerId,
                LimitType = (Events.LimitType)limit.LimitType,
                Limit = limit.Value,
                PeriodInDays = limit.PeriodInDays,
                StartDate = limit.StartDate,
                EndDate = limit.EndDate,
                Author = limit.Author,
                ModificationTime = DateTime.Now
            };
        }
    }
}
