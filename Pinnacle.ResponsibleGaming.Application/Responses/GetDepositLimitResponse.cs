using System;
using Pinnacle.ResponsibleGaming.Domain.Models;
using WebApi.Hal;

namespace Pinnacle.ResponsibleGaming.Application.Responses
{
    public class GetDepositLimitResponse: Representation
    {
        public int LimitId { get; set; }
        public string CustomerId { get; set; }
        public decimal Amount { get; set; }
        public int? PeriodInDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Author { get; set; }
        public DateTime ModificationTime { get; set; }
        public string Status { get; set; }
        public bool IsRecurring { get; set; }

        public GetDepositLimitResponse(DepositLimit depositLimit)
        {
            LimitId = depositLimit.LimitId;
            CustomerId = depositLimit.CustomerId;
            Amount = depositLimit.Amount;
            PeriodInDays = depositLimit.PeriodInDays;
            StartDate = depositLimit.StartDate;
            EndDate = depositLimit.EndDate;
            Author = depositLimit.Author;
            ModificationTime = depositLimit.ModificationTime;
            Status = depositLimit.Status.ToString();
            IsRecurring = depositLimit.IsRecurring;
        }
    }
}
