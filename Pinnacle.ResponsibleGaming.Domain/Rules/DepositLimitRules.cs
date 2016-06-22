using System;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Domain.Rules
{
    public static class DepositLimitRules
    {
        public static bool DepositLimitMustBeMoreRestrictive(DepositLimit currentDepositLimit, DepositLimit depositLimit)
        {
            return currentDepositLimit == null || currentDepositLimit.AmountInCents > depositLimit.AmountInCents;
        }
    }
}
