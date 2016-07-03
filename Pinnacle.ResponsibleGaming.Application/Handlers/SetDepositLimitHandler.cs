﻿using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Application._Common.Extensions;
using Pinnacle.ResponsibleGaming.Domain.Models;
using Pinnacle.ResponsibleGaming.Domain.Queries;
using Pinnacle.ResponsibleGaming.Read.Updaters;

namespace Pinnacle.ResponsibleGaming.Application.Handlers
{
    public class SetDepositLimitHandler
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DbContext _dbContext;
        private readonly DepositLimitQuery _depositLimitQuery;
        private readonly Bus.Bus _bus;

        public SetDepositLimitHandler(
            DbContext dbContext,
            DepositLimitQuery depositLimitQuery,
            Bus.Bus bus

            )
        {
            _dbContext = dbContext;
            _depositLimitQuery = depositLimitQuery;
            _bus = bus;
        }

        public async Task<bool> Handle(SetDepositLimit setDepositLimit)
        {
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                var newDepositLimit = setDepositLimit.ToDepositLimit();
                var depositLimit = await _depositLimitQuery.GetByCustomerId(setDepositLimit.CustomerId);

                depositLimit.ApplyNewLimit(newDepositLimit); 
                _dbContext.Set<Limit>().AddOrUpdate(depositLimit);

                //Save event (the event gets stored under the same transaction) 
                var depositLimitSet = setDepositLimit.ToDepositLimitSet(); 
                var @event = new Event(depositLimitSet);
                _dbContext.Set<Event>().Add(@event);

                //await _logUpdater.Update(depositLimitSet);
                await _bus.Publish(depositLimitSet);// this is temporary sa we cannot publish event without ensuring the commit

                //Save
                await _dbContext.SaveChangesAsync();

                //Commit
                dbContextTransaction.Commit();
            }
            _log.Info(setDepositLimit.SerializeAsKeyValues());

            return true;
        }
    }
}
