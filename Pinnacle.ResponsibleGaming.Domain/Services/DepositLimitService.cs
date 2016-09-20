using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Messages;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Domain.Repositories;
using Pinnacle.ResponsibleGaming.Domain._Framework.Exceptions;

namespace Pinnacle.ResponsibleGaming.Domain.Services
{
    public class DepositLimitService
    {
        private readonly IDepositLimitRepository _depositLimitRepository;
        private readonly ILogRepository _logRepository;
        private readonly IEventRepository _eventRepository;

        public DepositLimitService(IDepositLimitRepository depositLimitRepository, ILogRepository logRepository, IEventRepository eventRepository)
        {
            _depositLimitRepository = depositLimitRepository;
            _logRepository = logRepository;
            _eventRepository = eventRepository;
        }

        public async Task<DepositLimit> Set(DepositLimit depositLimit)
        {
            var currentDepositLimit = await Get(depositLimit.CustomerId);
            if (currentDepositLimit != null)
            {
                currentDepositLimit.Modify(depositLimit);
            }
            else
            {
                currentDepositLimit = depositLimit;
            }

            _depositLimitRepository.AddOrUpdate(currentDepositLimit);

            //Log deposit limit
            var log = new Log(depositLimit);
            _logRepository.Add(log);

            //Add events
            foreach (var @event in depositLimit.Events)
            {
                _eventRepository.Add(@event);
            }
            depositLimit.Events.Clear();

            return currentDepositLimit;
        }
        public async Task<DepositLimit> Disable(string customerId, string author)
        {
            var depositLimit = await _depositLimitRepository.GetActiveByCustomerId(customerId);
            if (depositLimit == null) throw new NotFoundException(DepositLimitMessages.DepositLimitNotFound);

            depositLimit.Disable(author);
            _depositLimitRepository.AddOrUpdate(depositLimit);

            //Log deposit limit
            var log = new Log(depositLimit);
            _logRepository.Add(log);

            return depositLimit;
        }
        public async Task<DepositLimit> Get(string customerId)
        {
            //Check if customer exists
            if (false) throw new NotFoundException(DepositLimitMessages.CustomerNotFound);

            var depositLimit = await _depositLimitRepository.GetActiveByCustomerId(customerId);
            return depositLimit;
        }
    }
}
