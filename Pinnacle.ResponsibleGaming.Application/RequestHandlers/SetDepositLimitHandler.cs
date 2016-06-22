﻿using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Pinnacle.ResponsibleGaming.Application.Extensions;
using Pinnacle.ResponsibleGaming.Domain.Contexts;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Domain.Models;
using Pinnacle.ResponsibleGaming.Domain.ModelValidators;

namespace Pinnacle.ResponsibleGaming.Application.RequestHandlers
{
    public class SetDepositLimitHandler
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly MainContext _mainDbContext;
        private readonly DepositLimitValidator _depositLimitValidator;

        public SetDepositLimitHandler(
            MainContext mainDbContext,
            DepositLimitValidator depositLimitValidator
            )
        {
            _mainDbContext = mainDbContext;
            _depositLimitValidator = depositLimitValidator;
        }

        public async Task Handle(SetDepositLimit setDepositLimit)
        {
            using (var dbContextTransaction = _mainDbContext.Database.BeginTransaction())
            {
                //Map
                var depositLimit = setDepositLimit.ToDepositLimit();

                //Validate
                await _depositLimitValidator.Validate(depositLimit);

                //Add deposit limit or modify existing      
                _mainDbContext.Limits.AddOrUpdate(depositLimit);

                //Save in log (this will go into the subscriber when I get the queue configured)
                var log = depositLimit.ToLog(setDepositLimit.GetType().Name);
                _mainDbContext.Logs.Add(log);

                //Save in event store
                var @event = new Event(depositLimit.ToDepositLimitSet());
                _mainDbContext.Event.Add(@event);

                //Save
                await _mainDbContext.SaveChangesAsync();

                //Commit
                dbContextTransaction.Commit();
            }
            _log.Info(setDepositLimit.SerializeAsKeyValues());  //This will also go as a handler into the subscriber
        }
    }
}