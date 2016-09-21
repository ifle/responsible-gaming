using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Domain.Services;
using Pinnacle.ResponsibleGaming.Infrastructure.Contexts;

namespace Pinnacle.ResponsibleGaming.Application.Handlers
{
    public class SetDepositLimitHandler
    {
        private readonly MainContext _context;
        private readonly LimitService _limitService;

        public SetDepositLimitHandler(
            MainContext context,
            LimitService limitService
            )
        {
            _context = context;
            _limitService = limitService;
        }

        public async Task Handle(SetDepositLimit setDepositLimit)
        {
            //Set deposit limit
            await _limitService.Set(setDepositLimit.ToLimit());

            //Save changes
            await _context.SaveChangesAsync();
        }
    }
}
