using Pinnacle.ResponsibleGaming.Domain.Models;


namespace Pinnacle.ResponsibleGaming.Application.Builders
{
    public static class StatusBuilder
    {
        public static string Build(LimitStatus limitStatus)
        {
            return limitStatus == LimitStatus.Active ? "Active" : "Expired";
        }
    }
}
