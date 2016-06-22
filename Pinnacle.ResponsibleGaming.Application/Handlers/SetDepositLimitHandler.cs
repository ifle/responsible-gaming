using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Pinnacle.ResponsibleGaming.Application._Common;
using Pinnacle.ResponsibleGaming.Persistence.Contexts;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Domain.Models;
using Pinnacle.ResponsibleGaming.Domain.Repositories;
using Pinnacle.ResponsibleGaming.Domain.Validators;

namespace Pinnacle.ResponsibleGaming.Application.Handlers
{
    public class SetDepositLimitHandler
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly MainContext _mainDbContext;
        private readonly IDepositLimitRepository _depositLimitRepository;
        private readonly DepositLimitValidator _depositLimitValidator;

        public SetDepositLimitHandler(
            MainContext mainDbContext,
            IDepositLimitRepository depositLimitRepository,
            DepositLimitValidator depositLimitValidator
            )
        {
            _mainDbContext = mainDbContext;
            _depositLimitRepository = depositLimitRepository;
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
                _depositLimitRepository.AddOrUpdate(depositLimit);

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
