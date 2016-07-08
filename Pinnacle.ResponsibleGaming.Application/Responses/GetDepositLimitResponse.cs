using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.Application.Responses
{
    public class GetDepositLimitResponse : DepositLimit
    {
        public GetDepositLimitResponse(DepositLimit depositLimit)
            :base(
                 depositLimit.CustomerId,
                 depositLimit.Amount,
                 depositLimit.PeriodInDays,
                 depositLimit.StartDate,
                 depositLimit.EndDate,
                 depositLimit.Author
                 )
        {
        }
    }
}
