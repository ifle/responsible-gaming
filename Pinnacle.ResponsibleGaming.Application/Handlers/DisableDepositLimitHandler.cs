﻿using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Domain.Services;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Infrastructure.Contexts;


namespace Pinnacle.ResponsibleGaming.Application.Handlers
{
    public class DisableDepositLimitHandler
    {
        private readonly ResponsibleGamingContext _context;
        private readonly LimitService _limitService;

        public DisableDepositLimitHandler(
            ResponsibleGamingContext context,
            LimitService limitService
            )
        {
            _context = context;
            _limitService = limitService;
        }

        public async Task Handle(DisableDepositLimit disableDepositLimit)
        {
            //Disable deposit limit
            await _limitService.Disable(disableDepositLimit.CustomerId, LimitType.DepositLimit, disableDepositLimit.Author);

            //Save changes
            await _context.SaveChangesAsync();
        }
    }
}
