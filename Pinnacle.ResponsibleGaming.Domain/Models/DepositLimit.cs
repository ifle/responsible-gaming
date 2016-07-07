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
            CustomerId = customerId;
            Amount = amount;
            PeriodInDays = periodInDays;
            StartDate = startDate ?? DateTime.Now;
            EndDate = endDate;
            Author = author;
        }

        public void Modify(decimal amount, int? periodInDays, DateTime? startDate, DateTime? endDate, string author)
        {
            if (!DepositLimitRules.NewLimitMustBeMoreRestrictiveThanTheCurrentOne(amount, Amount)) { throw new ConflictException(DepositLimitMessages.LimitMustBeMoreRestrictiveThanTheCurrentOne); }
            if (!DepositLimitRules.PeriodAndLimitCannotBeChangedAtOnce(amount, Amount, periodInDays, PeriodInDays)) { throw new ConflictException(DepositLimitMessages.PeriodAndLimitCannotBeChangedAtOnce); }          
            if (!DepositLimitRules.NewPeriodMustBeMoreRestrictiveThanTheCurrentOne(periodInDays, PeriodInDays)) { throw new ConflictException(DepositLimitMessages.PeriodMustBeMoreRestrictiveThanTheCurrentOne); }

            Amount = amount;
            PeriodInDays = periodInDays;
            StartDate = startDate??DateTime.Now;
            EndDate = endDate;
            Author = author;
            ModificationTime = DateTime.Now;
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
