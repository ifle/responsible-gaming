using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Pinnacle.ResponsibleGaming.Application.Contexts;
using Pinnacle.ResponsibleGaming.Application._Common;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Domain.Repositories;
using Pinnacle.ResponsibleGaming.Domain.Validators;

namespace Pinnacle.ResponsibleGaming.Application.Handlers
{
    public class SetDepositLimitHandler
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly SetDepositLimitContext _setDepositLimitContext;
        private readonly IDepositLimitRepository _depositLimitRepository;
        private readonly ILogRepository _logRepository;
        private readonly DepositLimitValidator _depositLimitValidator;

        public SetDepositLimitHandler(
            SetDepositLimitContext setDepositLimitContext,
            IDepositLimitRepository depositLimitRepository,
            ILogRepository logRepository,
            DepositLimitValidator depositLimitValidator
            )
        {
            _setDepositLimitContext = setDepositLimitContext;
            _depositLimitRepository = depositLimitRepository;
            _logRepository = logRepository;
            _depositLimitValidator = depositLimitValidator;
        }

        public async Task Handle(SetDepositLimit setDepositLimit)
        {
            //Begin transaction
            _setDepositLimitContext.BeginTransaction();

            //Map
            var depositLimit = setDepositLimit.ToDepositLimit();

            //Validate
            await _depositLimitValidator.Validate(depositLimit);

            //Add deposit limit or modify existing      
            _depositLimitRepository.AddOrUpdate(depositLimit);

            //Save in log (this model will go away when we listen from events in the cloud)
            var log = depositLimit.ToLog(setDepositLimit.GetType().Name);
            _logRepository.Add(log);

            //Save
            await _setDepositLimitContext.SaveChangesAsync(depositLimit.ToDepositLimitSet());

            //Commit
            _setDepositLimitContext.Commit();

            _log.Info(setDepositLimit.SerializeAsKeyValues()); 
        }
    }
}
