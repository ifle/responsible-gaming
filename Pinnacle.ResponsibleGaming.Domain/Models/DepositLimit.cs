using Pinnacle.ResponsibleGaming.Domain.Messages;
using Pinnacle.ResponsibleGaming.Domain.Rules;
using Pinnacle.ResponsibleGaming.Domain._Common.Exceptions;

namespace Pinnacle.ResponsibleGaming.Domain.Models
{
    public class DepositLimit : Limit
    {
        public decimal Amount { get; set; }

        public void Set(DepositLimit depositLimit)
        {
            if (!DepositLimitRules.NewDepositLimitMustBeMoreRestrictiveThanTheCurrentOne(depositLimit, this)) { throw new ConflictException(DepositLimitMessages.DepositLimitMustBeMoreRestrictive); }
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
