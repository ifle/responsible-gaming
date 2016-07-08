using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.Application.GetDepositLimit
{
    public class Response : DepositLimit
    {
        public Response(DepositLimit depositLimit)
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
