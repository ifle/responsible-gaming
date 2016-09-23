

namespace Pinnacle.ResponsibleGaming.Domain.Messages
{
    public static class LimitMessages
    {
        public const string PeriodAndLimitCannotBeChangedAtOnce = "The period and the limit cannot be modified at the same time";
        public const string LimitMustBeMoreRestrictiveThanTheCurrentOne = "The limit must be more restrictive";
        public const string PeriodMustBeMoreRestrictiveThanTheCurrentOne = "The period must be more restrictive";

        public const string CustomerNotFound = "Customer not found";
        public const string DepositLimitNotFound = "Deposit limit not found";
    }
}
