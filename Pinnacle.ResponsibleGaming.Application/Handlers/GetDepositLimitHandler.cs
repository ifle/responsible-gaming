using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Application.Responses;
using Pinnacle.ResponsibleGaming.Domain.Repositories;

namespace Pinnacle.ResponsibleGaming.Application.Handlers
{
    public class GetDepositLimitHandler
    {
        private readonly IDepositLimitRepository _depositLimitRepository;

        public GetDepositLimitHandler(IDepositLimitRepository depositLimitRepository)
        {
            _depositLimitRepository = depositLimitRepository;
        }

        public async Task<GetDepositLimitResponse> Handle(GetDepositLimit getDepositLimit)
        {
            var depositLimit =  await _depositLimitRepository.GetByCustomerId(getDepositLimit.CustomerId);
            if (depositLimit == null) return null;
            var getDepositLimitResult = new GetDepositLimitResponse(depositLimit);
            return getDepositLimitResult;
        }
    }
}
