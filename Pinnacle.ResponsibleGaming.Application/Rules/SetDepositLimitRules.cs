using System;

namespace Pinnacle.ResponsibleGaming.Application.Rules
{
    public static class SetDepositLimitRules
    {
        public static bool CustomerIdMustBeProvided(string customerId)
        {
            return !string.IsNullOrEmpty(customerId);
        }
        public static bool StartDateCannotBeAPastDate(DateTime? startDate)
        {
            return !startDate.HasValue || (startDate.Value - DateTime.Now).Days >= 0;
        }
        public static bool AmountMustBeAPositiveValue(decimal amount)
        {
            return amount > 0;
        }
    }
}
