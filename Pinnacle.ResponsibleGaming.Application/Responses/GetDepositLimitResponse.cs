using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.Application.Responses
{
    public class GetDepositLimitResponse 
    {
        public string CustomerId { get; set; }
        public decimal Amount { get; set; }
        public LimitStatus Status { get; set; }
        public bool IsRecurring { get; set; }
        public string PeriodInDays { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Author { get; set; }
        public string ModificationTime { get; set; }
     

        public GetDepositLimitResponse(DepositLimit depositLimit)
        {
            CustomerId = depositLimit.CustomerId;
            Amount = depositLimit.Amount;
            Status = depositLimit.Status;
            IsRecurring = depositLimit.IsRecurring;
            PeriodInDays = depositLimit.PeriodInDays.ToString();
            StartDate = depositLimit.StartDate.ToString("yyyy-MMM-dd HH:mm");
            EndDate = depositLimit.EndDate?.ToString("yyyy-MMM-dd HH:mm");
            Author = depositLimit.Author;
            ModificationTime = depositLimit.ModificationTime.ToString("yyyy-MMM-dd HH:mm");
        }
    }
}
