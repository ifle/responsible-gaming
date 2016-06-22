using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Persistence.Contexts;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Application.Responses;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Application.Handlers
{
    public class GetDepositLimitHandler
    {
        private readonly MainContext _mainDbContext;

        public GetDepositLimitHandler(MainContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task<GetDepositLimitResponse> Handle(GetDepositLimit getDepositLimit)
        {
            var depositLimit =  await _mainDbContext.Limits.OfType<DepositLimit>()
                .FirstOrDefaultAsync(x => x.CustomerId == getDepositLimit.CustomerId);
            if (depositLimit == null) return null;
            var getDepositLimitResult = new GetDepositLimitResponse(depositLimit);
            return getDepositLimitResult;
        }
    }
}
