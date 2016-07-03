

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
            if (!DepositLimitRules.NewDepositLimitMustBeMoreRestrictiveThanTheCurrentOne(depositLimit, this)) { throw new ConflictException(DepositLimitMessages.DepositLimitMustBeMoreRestrictive); }
            Map(depositLimit);
        }

        public void Map(DepositLimit depositLimit)
        {
            CustomerId = CustomerId;
            Amount = Amount;
            PeriodInDays = PeriodInDays;
            StartDate = StartDate;
            EndDate = EndDate;
        }
    }
}
