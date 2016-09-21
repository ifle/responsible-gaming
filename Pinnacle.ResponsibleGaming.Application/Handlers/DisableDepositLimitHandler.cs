<<<<<<< HEAD
﻿using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Application._Framework.Extensions;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Domain.Services;
using System.Data.Entity;
=======
﻿using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Domain.Services;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Infrastructure.Contexts;

>>>>>>> feature/with_messaging

namespace Pinnacle.ResponsibleGaming.Application.Handlers
{
    public class DisableDepositLimitHandler
    {
<<<<<<< HEAD
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private DbContext _context;
        private readonly DepositLimitService _depositLimitService;

        public DisableDepositLimitHandler(
           DbContext context,
           DepositLimitService depositLimitService

            )
        {
            _context = context;
            _depositLimitService = depositLimitService;
=======
        private readonly ResponsibleGamingContext _context;
        private readonly LimitService _limitService;

        public DisableDepositLimitHandler(
            ResponsibleGamingContext context,
            LimitService limitService
            )
        {
            _context = context;
            _limitService = limitService;
>>>>>>> feature/with_messaging
        }

        public async Task Handle(DisableDepositLimit disableDepositLimit)
        {
<<<<<<< HEAD
            //Begin transaction
            using (var transaction = _context.Database.BeginTransaction())
            {
                //Disable deposit limit
                var depositLimit = await _depositLimitService.Disable(disableDepositLimit.CustomerId, disableDepositLimit.Author);

                //Save changes
                await _context.SaveChangesAsync();

                //Commit                
                transaction.Commit();
            }                           

            //Log
            _log.Info(disableDepositLimit.SerializeAsKeyValues());
=======
            //Disable deposit limit
            await _limitService.Disable(disableDepositLimit.CustomerId, LimitType.DepositLimit, disableDepositLimit.Author);

            //Save changes
            await _context.SaveChangesAsync();
>>>>>>> feature/with_messaging
        }
    }
}
