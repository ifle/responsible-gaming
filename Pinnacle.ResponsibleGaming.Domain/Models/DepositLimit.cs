using System;
using Newtonsoft.Json;
using Pinnacle.ResponsibleGaming.Domain.Messages;
using Pinnacle.ResponsibleGaming.Domain.Rules;
using Pinnacle.ResponsibleGaming.Domain._Framework.Exceptions;

namespace Pinnacle.ResponsibleGaming.Domain.Models
{
    public class DepositLimit : Limit
    {
        [JsonProperty(Order = 3)]
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

            var now = DateTime.Now;

            Amount = depositLimit.Amount;
            PeriodInDays = depositLimit.PeriodInDays;
            EndDate = depositLimit.EndDate;
            Author = depositLimit.Author;
            ModificationTime = now;
        }
        public void Disable(string author)
        {
            const int coolingOffPeriodInDays = 1;

            EndDate = DateTime.Now.AddDays(coolingOffPeriodInDays);
            Author = author;
        }
    }
}
