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
using Pinnacle.ResponsibleGaming.Infrastructure.Contexts;
>>>>>>> feature/with_messaging

namespace Pinnacle.ResponsibleGaming.Application.Handlers
{
    public class SetDepositLimitHandler
    {
<<<<<<< HEAD
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DbContext _context;
        private readonly DepositLimitService _depositLimitService;

        public SetDepositLimitHandler(
            DbContext context,
            DepositLimitService depositLimitService

            )
        {
            _context = context;
            _depositLimitService = depositLimitService;
=======
        private readonly ResponsibleGamingContext _context;
        private readonly LimitService _limitService;

        public SetDepositLimitHandler(
            ResponsibleGamingContext context,
            LimitService limitService
            )
        {
            _context = context;
            _limitService = limitService;
>>>>>>> feature/with_messaging
        }

        public async Task Handle(SetDepositLimit setDepositLimit)
        {
<<<<<<< HEAD
            //Begin transaction
            using (var transaction = _context.Database.BeginTransaction())
            {
                //Set deposit limit
                var depositLimit = setDepositLimit.ToDepositLimit();
                depositLimit = await _depositLimitService.Set(depositLimit);

                //Save changes
                await _context.SaveChangesAsync();

                //Commit                
                transaction.Commit();
            }

            //Log deposit limit into Splunk
            _log.Info(setDepositLimit.SerializeAsKeyValues());
=======
            //Set deposit limit
            await _limitService.Set(setDepositLimit.ToLimit());

            //Save changes
            await _context.SaveChangesAsync();
>>>>>>> feature/with_messaging
        }
    }
}
