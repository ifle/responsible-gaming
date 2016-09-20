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
            var limit = await _limitRepository.Get(getDepositLimit.CustomerId, LimitType.DepositLimit);
            if (limit == null) return null;

            var getDepositLimitResult = new GetDepositLimitResponse(limit);
            return getDepositLimitResult;
        }
    }
}
