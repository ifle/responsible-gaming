using System.Reflection;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Messages;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Domain.Repositories;
using Pinnacle.ResponsibleGaming.Domain._Framework.Exceptions;
using Pinnacle.ResponsibleGaming.Domain._Framework.Extensions;

namespace Pinnacle.ResponsibleGaming.Domain.Services
{
    public class LimitService
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ILimitRepository _limitRepository;
        private readonly ILogRepository _logRepository;
        private readonly IEventRepository _eventRepository;

        public LimitService(ILimitRepository limitRepository, ILogRepository logRepository, IEventRepository eventRepository)
        {
            _limitRepository = limitRepository;
            _logRepository = logRepository;
            _eventRepository = eventRepository;
        }

        public async Task<Limit> Set(Limit limit)
        {
            var currentDepositLimit = await Get(limit.CustomerId, limit.LimitType);
            if (currentDepositLimit != null)
            {
                currentDepositLimit.Modify(limit);
            }
            else
            {
                currentDepositLimit = limit;
            }

            _limitRepository.AddOrUpdate(currentDepositLimit);

            //Log deposit limit
            var log = new Log(limit);
            _logRepository.Add(log);

            //Add events
            foreach (var @event in limit.Events)
            {
                _eventRepository.Add(@event);
                //Log deposit limit into Splunk
                _log.Info(@event.SerializeAsKeyValues());
            }
            limit.Events.Clear();

            return currentDepositLimit;
        }
        public async Task<Limit> Disable(string customerId, LimitType limitType, string author)
        {
            var limit = await _limitRepository.Get(customerId, limitType);
            if (limit == null) throw new NotFoundException(LimitMessages.DepositLimitNotFound);

            limit.Disable(author);
            _limitRepository.AddOrUpdate(limit);

            //Log deposit limit
            var log = new Log(limit);
            _logRepository.Add(log);

            return limit;
        }
        public async Task<Limit> Get(string customerId, LimitType limitType)
        {
            //Check if customer exists
            if (false) throw new NotFoundException(LimitMessages.CustomerNotFound);

            var limit = await _limitRepository.Get(customerId, limitType);
            return limit;
        }
    }
}
