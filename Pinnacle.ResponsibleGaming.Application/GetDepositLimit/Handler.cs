using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Repositories;

namespace Pinnacle.ResponsibleGaming.Application.GetDepositLimit
{
    public class Handler
    {
        private readonly IDepositLimitRepository _depositLimitRepository;

        public Handler(IDepositLimitRepository depositLimitRepository)
        {
            _depositLimitRepository = depositLimitRepository;
        }

        public async Task<Response> Handle(Request getDepositLimit)
        {
            var depositLimit = await _depositLimitRepository.GetActiveByCustomerId(getDepositLimit.CustomerId);
            if (depositLimit == null) return null;

            var getDepositLimitResult = new Response(depositLimit);
            return getDepositLimitResult;
        }
    }
}
