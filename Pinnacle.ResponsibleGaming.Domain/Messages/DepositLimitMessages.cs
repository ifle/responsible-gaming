

namespace Pinnacle.ResponsibleGaming.Domain.Messages
{
    public static class DepositLimitMessages
    {
        public const string PeriodAndLimitCannotBeChangedAtOnce = "The period and the limit cannot be modified at once";
        public const string LimitMustBeMoreRestrictiveThanTheCurrentOne = "The limit must be more restrictive";
        public const string PeriodMustBeMoreRestrictiveThanTheCurrentOne = "The period must be more restrictive";

        public const string CustomerNotFound = "Customer not found";
    }
}
