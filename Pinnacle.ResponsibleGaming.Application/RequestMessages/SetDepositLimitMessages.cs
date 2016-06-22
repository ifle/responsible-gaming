

namespace Pinnacle.ResponsibleGaming.Application.RequestMessages
{
    public static class SetDepositLimitMessages
    {
        public const string CustomerIdDoesNotExist = "The provided customer ID does not exist";
        public const string StartDateCannotBeAPastDate = "The start date cannot be a past date";
        public const string AuthorMustBeProvided = "An author must be provided";
    }
}
