using System;
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

            ApplyEvent(new LimitSet
            {
                CustomerId = customerId,
                LimitType = (Events.LimitType)limitType,
                Limit = value,
                PeriodInDays = periodInDays,
                StartDate = startDate ?? now,
                EndDate = endDate,
                Author = author,
                ModificationTime = now
            });
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

            // Apply event
            ApplyEvent(new LimitSet
            {
                CustomerId = CustomerId,
                LimitType = (Events.LimitType)LimitType,
                Limit = value,
                PeriodInDays = periodInDays,
                StartDate = StartDate,
                EndDate = endDate,
                Author = author,
                ModificationTime = DateTime.Now
            });
        }
        public void Disable(string author)
        {
            var now = DateTime.Now;

            ApplyEvent(new LimitSet
            {
                CustomerId = CustomerId,
                LimitType = (Events.LimitType)LimitType,
                Limit = Value,
                PeriodInDays = PeriodInDays,
                StartDate = StartDate,
                EndDate = now.AddDays(1),//TODO: (Cesar) Cooling-off period is for now fixed (1 day from the moment the limit gets set)
                Author = author,
                ModificationTime = now
            });
        }

        public void ApplyEvent(LimitSet limitSet)
        {
            Events.Add(new Event(limitSet));

            CustomerId = limitSet.CustomerId;
            LimitType = (LimitType) limitSet.LimitType;
            Value = limitSet.Limit;
            PeriodInDays = limitSet.PeriodInDays;
            StartDate = limitSet.StartDate;
            EndDate = limitSet.EndDate;
            Author = limitSet.Author;
            ModificationTime = limitSet.ModificationTime;
        }
    }
}
