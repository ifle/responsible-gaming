using Pinnacle.ResponsibleGaming.Bus.Events;
using Pinnacle.ResponsibleGaming.Read.Views;

namespace Pinnacle.ResponsibleGaming.Read.Mappers
{
    public static class LogMapper
    {
        public static Log Map(this Log t, DepositLimitSet depositLimitSet)
        {
            t.Action = depositLimitSet.GetType().Name;
            t.CustomerId = depositLimitSet.CustomerId;
            t.Limit = depositLimitSet.Amount;
            t.PeriodInDays = depositLimitSet.PeriodInDays;
            t.StartDate = depositLimitSet.StartDate;
            t.EndDate = depositLimitSet.EndDate;
            t.Author = depositLimitSet.Author;
            t.CreationTime = depositLimitSet.CreationTime;

            return t;
        }
    }
}
