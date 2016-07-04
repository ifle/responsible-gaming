using Pinnacle.ResponsibleGaming.Domain.Models;



namespace Pinnacle.ResponsibleGaming.Domain.Rules
{
    public static class DepositLimitRules
    {
        public static bool NewDepositLimitMustBeMoreRestrictiveThanTheCurrentOne(DepositLimit newDepositLimit, DepositLimit currentDepositLimit)
        {
            return currentDepositLimit.Amount == 0 || currentDepositLimit.Amount > newDepositLimit.Amount;
        }
    }
}
