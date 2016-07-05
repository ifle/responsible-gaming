using Pinnacle.ResponsibleGaming.Domain.Messages;
using Pinnacle.ResponsibleGaming.Domain.Rules;
using Pinnacle.ResponsibleGaming.Domain._Common.Exceptions;

namespace Pinnacle.ResponsibleGaming.Domain.Models
{
    public class DepositLimit : Limit
    {
        public decimal Amount { get; set; }

        public void ApplyNewLimit(DepositLimit depositLimit)
        {
            if (!DepositLimitRules.NewLimitMustBeMoreRestrictiveThanTheCurrentOne(depositLimit.Amount, Amount)) { throw new ConflictException(DepositLimitMessages.LimitMustBeMoreRestrictiveThanTheCurrentOne); }
            if (!DepositLimitRules.PeriodAndLimitCannotBeChangedAtOnce(depositLimit.Amount, Amount, depositLimit.PeriodInDays, PeriodInDays)) { throw new ConflictException(DepositLimitMessages.LimitMustBeMoreRestrictiveThanTheCurrentOne); }          
            if (!DepositLimitRules.NewPeriodMustBeMoreRestrictiveThanTheCurrentOne(depositLimit.PeriodInDays, PeriodInDays)) { throw new ConflictException(DepositLimitMessages.PeriodMustBeMoreRestrictiveThanTheCurrentOne); }
            Map(depositLimit);
        }

        private void Map(DepositLimit depositLimit)
        {
            CustomerId = depositLimit.CustomerId;
            Amount = depositLimit.Amount;
            PeriodInDays = depositLimit.PeriodInDays;
            StartDate = depositLimit.StartDate;
            EndDate = depositLimit.EndDate;
            Author = depositLimit.Author;
            CreationTime = depositLimit.CreationTime;
        }
    }
}
