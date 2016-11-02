using System;
using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.Application.Responses
{
    public class GetDepositLimitResponse
    {
        public decimal Amount { get; set; }
        public int? PeriodInDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Author { get; set; }
        public DateTime ModificationTime { get; set; }
        public string Status { get; set; }
        public bool IsRecurring { get; set; }

        public GetDepositLimitResponse(Limit limit)
        {
            Amount = limit.Value;
            PeriodInDays = limit.PeriodInDays;
            StartDate = limit.StartDate;
            EndDate = limit.EndDate;
            Author = limit.Author;
            ModificationTime = limit.ModificationTime;
            Status = limit.Status.ToString();
            IsRecurring = limit.IsRecurring;
        }
    }
}
