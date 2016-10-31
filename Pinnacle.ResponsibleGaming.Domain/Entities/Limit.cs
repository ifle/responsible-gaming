using System;
using Pinnacle.ResponsibleGaming.Domain.Builders;
using Pinnacle.ResponsibleGaming.Domain.Expressions;
using Pinnacle.ResponsibleGaming.Domain.Messages;
using Pinnacle.ResponsibleGaming.Domain.Rules;
using Pinnacle.ResponsibleGaming.Domain._Framework.Exceptions;
using Pinnacle.ResponsibleGaming.Events;

namespace Pinnacle.ResponsibleGaming.Domain.Entities
{
    public class Limit : Entity
    {
        public string CustomerId { get; set; }
        public LimitType LimitType { get; set; }
        public int? PeriodInDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Value { get; set; }
        public string Author { get; set; }
        public DateTime ModificationTime { get; set; }
        public LimitStatus Status => LimitExpressions.IsActive().Compile()(this) ? LimitStatus.Active : LimitStatus.Expired;
        public bool IsRecurring => PeriodInDays.HasValue;

        public Limit() { }

        public Limit(string customerId, LimitType limitType, decimal value, int? periodInDays, DateTime? startDate, DateTime? endDate, string author)
        {
            var now = DateTime.Now;

            CustomerId = customerId;
            LimitType = limitType;
            Value = value;
            PeriodInDays = periodInDays;
            StartDate = startDate ?? now;
            EndDate = endDate;
            Author = author;
            ModificationTime = now;

            // Add event
            AddEvent(new LimitSet().Build(this));
        }

        public void Modify(decimal value, int? periodInDays, DateTime? endDate, string author)
        {
            // Apply common business rules
            //TODO: (Cesar) Check that the new limit is different
            if (!LimitRules.NewLAmountMustBeMoreRestrictiveThanTheCurrentOne(value, Value)) { throw new ConflictException(LimitMessages.LimitMustBeMoreRestrictiveThanTheCurrentOne); }
            if (!LimitRules.PeriodAndAmountCannotBeChangedAtOnce(value, Value, periodInDays, PeriodInDays)) { throw new ConflictException(LimitMessages.PeriodAndLimitCannotBeChangedAtTheSameTime); }
            if (!LimitRules.NewPeriodMustBeMoreRestrictiveThanTheCurrentOne(periodInDays, PeriodInDays)) { throw new ConflictException(LimitMessages.PeriodMustBeMoreRestrictiveThanTheCurrentOne); }

            // Apply specific business rules for each limit type
            switch (LimitType)
            {
                case LimitType.DepositLimit:
                    //TODO: (Cesar)
                    break;
                case LimitType.SelfExclusion:
                    //TODO: (Cesar)
                    break;
            }

            // Modify limit
            Value = value;
            PeriodInDays = periodInDays;
            EndDate = endDate;
            Author = author;
            ModificationTime = DateTime.Now;

            // Add event
            AddEvent(new LimitSet().Build(this));
        }
        public void Disable(string author)
        {
            var now = DateTime.Now;
            EndDate = now.AddDays(1); // Cooling-off period
            Author = author;

            // Add event
            AddEvent(new LimitSet().Build(this));
        }
    }
}
