﻿using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Application.Contexts;
using Pinnacle.ResponsibleGaming.Application._Framework.Extensions;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Domain.Services;
using Pinnacle.ResponsibleGaming.Events;

namespace Pinnacle.ResponsibleGaming.Application.Handlers
{
    public class SetDepositLimitHandler
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ISetDepositLimitContext _setDepositLimitContext;
        private readonly DepositLimitService _depositLimitService;
        private readonly LogService _logService;
        private readonly EventService _eventService;

        public SetDepositLimitHandler(
            ISetDepositLimitContext setDepositLimitContext,
            DepositLimitService depositLimitService,
            LogService logService,
            EventService eventService

            )
        {
            _setDepositLimitContext = setDepositLimitContext;
            _depositLimitService = depositLimitService;
            _logService = logService;
            _eventService = eventService;
        }

        public async Task Handle(SetDepositLimit setDepositLimit)
        {
            //Begin transaction
            _setDepositLimitContext.BeginTransaction();

            //Set deposit limit
            var depositLimit = setDepositLimit.ToDepositLimit();
            depositLimit = await _depositLimitService.Set(depositLimit);

            //Log deposit limit
            var log = new Log(depositLimit);
            await _logService.Add(log);

            //Add events
            foreach (var @event in depositLimit.Events)
            {
                await _eventService.Add(@event);
            }

            //Commit                
            _setDepositLimitContext.Commit();

            //Log deposit limit into Splunk
            _log.Info(setDepositLimit.SerializeAsKeyValues());
        }
    }
}
