﻿using System;
using Pinnacle.ResponsibleGaming.Domain.Expressions;

namespace Pinnacle.ResponsibleGaming.Domain.Entities
{
    public abstract class Limit: Entity
    {
        public int LimitId { get; set; }
        public string CustomerId { get; set; }
        public int? PeriodInDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Author { get; set; }
        public DateTime ModificationTime { get; set; }
        public LimitStatus Status
        {
            get
            {
                if (LimitExpressions.IsActiveLimit<Limit>().Compile()(this))
                    return LimitStatus.Active;
                return LimitStatus.Expired;
            }
        }
        public bool IsRecurring => PeriodInDays.HasValue;
    }
}