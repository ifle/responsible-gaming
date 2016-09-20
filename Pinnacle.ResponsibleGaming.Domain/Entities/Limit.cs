﻿using System;
using Pinnacle.ResponsibleGaming.Domain.Expressions;

namespace Pinnacle.ResponsibleGaming.Domain.Entities
{
    public abstract class Limit
    {
        public int LimitId { get; set; }
        public string CustomerId { get; set; }
        public int? PeriodInDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Author { get; set; }
        public DateTime ModificationTime { get; set; }
        public LimitStatus Status => LimitExpressions.IsActiveLimit<Limit>().Compile()(this) ? LimitStatus.Active : LimitStatus.Expired;
        public bool IsRecurring => PeriodInDays.HasValue;


        public void ApplyCoolingOffPeriod()
        {
            // For now, let's make the cooling-off period stastic
            const int coolingOffPeriodInDays = 1;

            // Apply coolng-off period
            EndDate = DateTime.Now.AddDays(coolingOffPeriodInDays);
        }
    }
}