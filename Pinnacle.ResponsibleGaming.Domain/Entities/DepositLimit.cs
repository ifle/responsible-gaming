using System;
using Pinnacle.ResponsibleGaming.Domain.Events;
using Pinnacle.ResponsibleGaming.Domain.Messages;
using Pinnacle.ResponsibleGaming.Domain.Rules;
using Pinnacle.ResponsibleGaming.Domain._Framework.Exceptions;

namespace Pinnacle.ResponsibleGaming.Domain.Entities
{
    public class DepositLimit : Limit
    {
        public decimal Amount { get; set; }

        public DepositLimit()
        {
        }
        public DepositLimit(string customerId, decimal amount, int? periodInDays, DateTime? startDate, DateTime? endDate, string author)
        {
            var now = DateTime.Now;

            var depositLimitSet = new DepositLimitSet
            {
                CustomerId = customerId,
                Amount = amount,
                PeriodInDays = periodInDays,
                StartDate = startDate ?? now,
                EndDate = endDate,
                Author = author,
                ModificationTime = now
            };

            ApplyEvent(depositLimitSet);
        }

        public void Modify(DepositLimit depositLimit)
        {
            if (!DepositLimitRules.NewLimitMustBeMoreRestrictiveThanTheCurrentOne(depositLimit.Amount, Amount)) { throw new ConflictException(DepositLimitMessages.LimitMustBeMoreRestrictiveThanTheCurrentOne); }
            if (!DepositLimitRules.PeriodAndLimitCannotBeChangedAtOnce(depositLimit.Amount, Amount, depositLimit.PeriodInDays, PeriodInDays)) { throw new ConflictException(DepositLimitMessages.PeriodAndLimitCannotBeChangedAtOnce); }
            if (!DepositLimitRules.NewPeriodMustBeMoreRestrictiveThanTheCurrentOne(depositLimit.PeriodInDays, PeriodInDays)) { throw new ConflictException(DepositLimitMessages.PeriodMustBeMoreRestrictiveThanTheCurrentOne); }

            var depositLimitSet = new DepositLimitSet
            {
                CustomerId = CustomerId,
                Amount = depositLimit.Amount,
                PeriodInDays = depositLimit.PeriodInDays,
                StartDate = StartDate,
                EndDate = depositLimit.EndDate,
                Author = depositLimit.Author,
                ModificationTime = depositLimit.ModificationTime
            };

            ApplyEvent(depositLimitSet);
        }
        public void Disable(string author)
        {
            const int coolingOffPeriodInDays = 1;

            var depositLimitSet = new DepositLimitSet
            {
                CustomerId = CustomerId,
                Amount = Amount,
                PeriodInDays = PeriodInDays,
                StartDate = StartDate,
                EndDate = DateTime.Now.AddDays(coolingOffPeriodInDays),
                Author = author,
                ModificationTime = DateTime.Now
            };

            ApplyEvent(depositLimitSet);
        }

        public void ApplyEvent(DepositLimitSet depositLimitSet)
        {
            CustomerId = depositLimitSet.CustomerId;
            Amount = depositLimitSet.Amount;
            PeriodInDays = depositLimitSet.PeriodInDays;
            StartDate = depositLimitSet.StartDate;
            EndDate = depositLimitSet.EndDate;
            Author = depositLimitSet.Author;
            ModificationTime = depositLimitSet.ModificationTime;

            Events.Add(new Event(depositLimitSet));
        }
    }
}
