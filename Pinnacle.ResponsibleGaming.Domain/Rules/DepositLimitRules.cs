using System;
using Pinnacle.ResponsibleGaming.Domain.Events;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Domain.Rules
{
    public static class DepositLimitRules
    {
        public static bool NewDepositLimitMustBeMoreRestrictiveThanTheCurrentOne(DepositLimitSet depositLimitSet, DepositLimit currentDepositLimit)
        {
            return currentDepositLimit.Amount == 0 || currentDepositLimit.Amount > depositLimitSet.Amount;
        }
    }
}
