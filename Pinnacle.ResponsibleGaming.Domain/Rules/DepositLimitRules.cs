using Pinnacle.ResponsibleGaming.Domain.Models;



namespace Pinnacle.ResponsibleGaming.Domain.Rules
{
    public static class DepositLimitRules
    {
        public static bool PeriodAndLimitCannotBeChangedAtOnce(decimal newAmount, decimal currentAmount, int? newPeriod, int? currentPeriod)
        {
            return newAmount == currentAmount || newPeriod == currentPeriod;
        }
        public static bool NewLimitMustBeMoreRestrictiveThanTheCurrentOne(decimal newAmount, decimal currentAmount)
        {
            return newAmount < currentAmount;
        }
        public static bool NewPeriodMustBeMoreRestrictiveThanTheCurrentOne(int? newPeriod, int? currentPeriod)
        {
            return newPeriod >= currentPeriod;
        }
    }
}
