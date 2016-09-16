using Pinnacle.ResponsibleGaming.Domain.Entities;



namespace Pinnacle.ResponsibleGaming.Domain.Rules
{
    public static class DepositLimitRules
    {
        public static bool PeriodAndAmountCannotBeChangedAtOnce(decimal newAmount, decimal currentAmount, int? newPeriod, int? currentPeriod)
        {
            return newAmount == currentAmount || newPeriod == currentPeriod;
        }
        public static bool NewLAmountMustBeMoreRestrictiveThanTheCurrentOne(decimal newAmount, decimal currentAmount)
        {
            return newAmount < currentAmount;
        }
        public static bool NewPeriodMustBeMoreRestrictiveThanTheCurrentOne(int? newPeriod, int? currentPeriod)
        {
            return newPeriod >= currentPeriod;
        }
    }
}
