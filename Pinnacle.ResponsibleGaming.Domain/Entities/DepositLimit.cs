using System;
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

            CustomerId = customerId;
            Amount = amount;
            PeriodInDays = periodInDays;
            StartDate = startDate ?? now;
            EndDate = endDate;
            Author = author;
            ModificationTime = now;
        }

        public void Modify(DepositLimit depositLimit)
        {
            // Apply business rules
            if (!DepositLimitRules.NewLimitMustBeMoreRestrictiveThanTheCurrentOne(depositLimit.Amount, Amount)) { throw new ConflictException(DepositLimitMessages.LimitMustBeMoreRestrictiveThanTheCurrentOne); }
            if (!DepositLimitRules.PeriodAndLimitCannotBeChangedAtOnce(depositLimit.Amount, Amount, depositLimit.PeriodInDays, PeriodInDays)) { throw new ConflictException(DepositLimitMessages.PeriodAndLimitCannotBeChangedAtOnce); }
            if (!DepositLimitRules.NewPeriodMustBeMoreRestrictiveThanTheCurrentOne(depositLimit.PeriodInDays, PeriodInDays)) { throw new ConflictException(DepositLimitMessages.PeriodMustBeMoreRestrictiveThanTheCurrentOne); }

            // Modify properties
            Amount = depositLimit.Amount;
            PeriodInDays = depositLimit.PeriodInDays;
            EndDate = depositLimit.EndDate;
            Author = depositLimit.Author;
            ModificationTime = depositLimit.ModificationTime;
        }
        public void Disable(string author)
        {
            ApplyCoolingOffPeriod();
            Author = author;
        }
    }
}
