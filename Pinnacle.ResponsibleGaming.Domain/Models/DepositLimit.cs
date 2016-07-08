using System;
using Pinnacle.ResponsibleGaming.Domain.Messages;
using Pinnacle.ResponsibleGaming.Domain.Rules;
using Pinnacle.ResponsibleGaming.Domain._Common.Exceptions;

namespace Pinnacle.ResponsibleGaming.Domain.Models
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
            if (!DepositLimitRules.NewLimitMustBeMoreRestrictiveThanTheCurrentOne(depositLimit.Amount, Amount)) { throw new ConflictException(DepositLimitMessages.LimitMustBeMoreRestrictiveThanTheCurrentOne); }
            if (!DepositLimitRules.PeriodAndLimitCannotBeChangedAtOnce(depositLimit.Amount, Amount, depositLimit.PeriodInDays, PeriodInDays)) { throw new ConflictException(DepositLimitMessages.PeriodAndLimitCannotBeChangedAtOnce); }
            if (!DepositLimitRules.NewPeriodMustBeMoreRestrictiveThanTheCurrentOne(depositLimit.PeriodInDays, PeriodInDays)) { throw new ConflictException(DepositLimitMessages.PeriodMustBeMoreRestrictiveThanTheCurrentOne); }

            Amount = depositLimit.Amount;
            PeriodInDays = depositLimit.PeriodInDays;
            EndDate = depositLimit.EndDate;
            Author = depositLimit.Author;
            ModificationTime = depositLimit.ModificationTime;
        }

        public Log ToLog()
        {
            return new Log
            {
                LimitId = LimitId,
                CustomerId = CustomerId,
                LimitTypeId = (int)LimitType.DepositLimit,
                Limit = Amount,
                PeriodInDays = PeriodInDays,
                StartDate = StartDate,
                EndDate = EndDate,
                Author = Author,
                ModificationTime = ModificationTime
            };
        }
    }
}
