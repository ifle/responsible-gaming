using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Application.Responses;
using Pinnacle.ResponsibleGaming.Domain.Queries;

namespace Pinnacle.ResponsibleGaming.Application.Handlers
{
    public class GetDepositLimitHandler
    {
        private readonly DepositLimitQuery _depositLimitQuery;

        public GetDepositLimitHandler(DepositLimitQuery depositLimitQuery)
        {
            _depositLimitQuery = depositLimitQuery;
        }

        public async Task<GetDepositLimitResponse> Handle(GetDepositLimit getDepositLimit)
        {
            var depositLimit = await _depositLimitQuery.GetByCustomerIdAsync(getDepositLimit.CustomerId);
            if (depositLimit == null) return null;
            var getDepositLimitResult = new GetDepositLimitResponse(depositLimit);
            return getDepositLimitResult;
        }
    }
}
