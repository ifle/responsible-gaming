using Pinnacle.ResponsibleGaming.Domain.Events;
using Pinnacle.ResponsibleGaming.Domain.Messages;
using Pinnacle.ResponsibleGaming.Domain.Rules;
using Pinnacle.ResponsibleGaming.Domain._Common.Exceptions;

namespace Pinnacle.ResponsibleGaming.Domain.Models
{
    public class DepositLimit : Limit
    {
        public decimal Amount { get; set; }

        public void Apply(DepositLimitSet depositLimitSet)
        {
            if (!DepositLimitRules.NewDepositLimitMustBeMoreRestrictiveThanTheCurrentOne(depositLimitSet, this)) { throw new ConflictException(DepositLimitMessages.DepositLimitMustBeMoreRestrictive); }
            Map(depositLimitSet);
        }

        public void Map(DepositLimitSet depositLimitSet)
        {
            CustomerId = depositLimitSet.CustomerId;
            Amount = depositLimitSet.Amount;
            PeriodInDays = depositLimitSet.PeriodInDays;
            StartDate = depositLimitSet.StartDate;
            EndDate = depositLimitSet.EndDate;
            Author = depositLimitSet.Author;
            CreationTime = depositLimitSet.CreationTime;
        }
    }
}
