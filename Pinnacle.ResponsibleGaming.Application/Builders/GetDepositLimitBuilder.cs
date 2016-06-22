using Pinnacle.ResponsibleGaming.Domain.Models;


namespace Pinnacle.ResponsibleGaming.Application.Builders
{
    public static class GetDepositLimitBuilder
    {
        public static string BuildStatus(LimitStatus limitStatus)
        {
            return limitStatus == LimitStatus.Active ? "Active" : "Expired";
        }
    }
}
