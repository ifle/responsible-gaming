using System;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Domain.Rules
{
    public static class DepositLimitRules
    {
        public static bool NewDepositLimitMustBeMoreRestrictiveThanTheCurrentOne(DepositLimit depositLimit, DepositLimit currentDepositLimit)
        {
            return currentDepositLimit == null || currentDepositLimit.AmountInCents > depositLimit.AmountInCents;
        }
    }
}
