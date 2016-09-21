using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Application.Responses;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Domain.Repositories;

namespace Pinnacle.ResponsibleGaming.Application.Handlers
{
    public class GetDepositLimitHandler
    {
        private readonly ILimitRepository _limitRepository;

        public GetDepositLimitHandler(ILimitRepository limitRepository)
        {
            _limitRepository = limitRepository;
        }

        public async Task<GetDepositLimitResponse> Handle(GetDepositLimit getDepositLimit)
        {
            // Retrieve limit
            var limit = await _limitRepository.Get(getDepositLimit.CustomerId, LimitType.DepositLimit);

            // Return null if it doesn't exist
            if (limit == null) return null;

            // Return result
            var getDepositLimitResult = new GetDepositLimitResponse(limit);
            return getDepositLimitResult;
        }
    }
}
