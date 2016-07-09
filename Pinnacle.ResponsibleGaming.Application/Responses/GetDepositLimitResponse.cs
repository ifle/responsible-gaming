using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.Application.Responses
{
    public class GetDepositLimitResponse : DepositLimit
    {
        public GetDepositLimitResponse(DepositLimit depositLimit)
        {
            CustomerId = depositLimit.CustomerId;
            Amount = depositLimit.Amount;
            PeriodInDays = depositLimit.PeriodInDays;
            StartDate = depositLimit.StartDate;
            EndDate = depositLimit.EndDate;
            Author = depositLimit.Author;
            ModificationTime = depositLimit.ModificationTime;
        }
    }
}
