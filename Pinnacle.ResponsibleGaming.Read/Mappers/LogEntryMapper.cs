using Pinnacle.ResponsibleGaming.Domain.Events;
using Pinnacle.ResponsibleGaming.Read.Models;

namespace Pinnacle.ResponsibleGaming.Read.Mappers
{
    public static class LogEntryMapper
    {
        public static LogEntry Map(this LogEntry t, DepositLimitSet depositLimitSet)
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

        public static LogEntry Map(this LogEntry t, DepositLimitDisabled depositLimitDisabled)
        {
            t.Action = depositLimitDisabled.GetType().Name;
            t.CustomerId = depositLimitDisabled.CustomerId;
            t.Author = depositLimitDisabled.Author;
            t.CreationTime = depositLimitDisabled.CreationTime;

            return t;
        }
    }
}
