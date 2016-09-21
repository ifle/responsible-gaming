using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Domain.Services;
using System.Data.Entity;
using Pinnacle.ResponsibleGaming.Infrastructure.Contexts;

namespace Pinnacle.ResponsibleGaming.Application.Handlers
{
    public class SetDepositLimitHandler
    {
        private readonly DbContext _context;
        private readonly LimitService _limitService;

        public SetDepositLimitHandler(
            DbContext context,
            LimitService limitService
            )
        {
            _context = context;
            _limitService = limitService;
        }

        public async Task Handle(SetDepositLimit setDepositLimit)
        {
            using (var context = new ResponsibleGamingContext())
            {
                //Set deposit limit
                await _limitService.Set(setDepositLimit.ToLimit());

                //Save changes
                await _context.SaveChangesAsync();
            }
        }
    }
}
