using Pinnacle.ResponsibleGaming.Application.Builders;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Application.Responses
{

    public  class GetDepositLimitResponse : DepositLimit
    {
        public new string Status { get; set; }

        public GetDepositLimitResponse(DepositLimit depositLimit)
        {
            CustomerId = depositLimit.CustomerId;
            AmountInCents = depositLimit.AmountInCents;
            PeriodInDays = depositLimit.PeriodInDays;
            StartDate = depositLimit.StartDate;
            EndDate = depositLimit.EndDate;
            Status = StatusBuilder.Build(depositLimit.Status);
            Author = depositLimit.Author;
            CreationTime = depositLimit.CreationTime;
        }
    }
}
