using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Domain.Services;
using System.Data.Entity;
using Pinnacle.ResponsibleGaming.Domain.Entities;


namespace Pinnacle.ResponsibleGaming.Application.Handlers
{
    public class DisableDepositLimitHandler
    {
        private readonly DbContext _context;
        private readonly LimitService _limitService;
        public DisableDepositLimitHandler(
           DbContext context,
           LimitService limitService
            )
        {
            _context = context;
            _limitService = limitService;
        }

        public async Task Handle(DisableDepositLimit disableDepositLimit)
        {
            //Disable deposit limit
            await _limitService.Disable(disableDepositLimit.CustomerId, LimitType.DepositLimit,  disableDepositLimit.Author);
            
            //Save changes
            await _context.SaveChangesAsync();
        }
    }
}
