using Pinnacle.ResponsibleGaming.Domain.Models;



namespace Pinnacle.ResponsibleGaming.Domain.Rules
{
    public static class DepositLimitRules
    {
        public static bool NewDepositLimitMustBeMoreRestrictiveThanTheCurrentOne(DepositLimit newDepositLimit, DepositLimit currentDepositLimit)
        {
            return currentDepositLimit.Amount > newDepositLimit.Amount;
        }
    }
}
