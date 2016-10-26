using System;
using Pinnacle.ResponsibleGaming.Events;


namespace Pinnacle.ResponsibleGaming.Domain.Entities
{
    public class Log
    {
        public int LogId { get; set; }
        public string CustomerId { get; set; }
        public LimitType LimitType { get; set; }
        public decimal Limit { get; set; }
        public int? PeriodInDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Author { get; set; }
        public DateTime ModificationTime { get; set; }

        public Log(Limit limit)
        {
            CustomerId = limit.CustomerId;
            LimitType = limit.LimitType;
            Limit = limit.Value;
            PeriodInDays = limit.PeriodInDays;
            StartDate = limit.StartDate;
            EndDate = limit.EndDate;
            Author = limit.Author;
            ModificationTime = limit.ModificationTime;
        }

        public Log(LimitSet limitSet)
        {
            CustomerId = limitSet.CustomerId;
            LimitType = (LimitType)limitSet.LimitType;
            Limit = limitSet.Limit;
            PeriodInDays = limitSet.PeriodInDays;
            StartDate = limitSet.StartDate;
            EndDate = limitSet.EndDate;
            Author = limitSet.Author;
            ModificationTime = limitSet.ModificationTime;
        }
    }
}
