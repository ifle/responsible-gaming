using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Messages;
using Pinnacle.ResponsibleGaming.Domain.Models;
using Pinnacle.ResponsibleGaming.Domain.Repositories;
using Pinnacle.ResponsibleGaming.Domain._Framework.Exceptions;

namespace Pinnacle.ResponsibleGaming.Domain.Services
{
    public class DepositLimitService
    {
        private readonly IDepositLimitRepository _depositLimitRepository;

        public DepositLimitService(IDepositLimitRepository depositLimitRepository)
        {
            _depositLimitRepository = depositLimitRepository;
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

            await _depositLimitRepository.Upsert(currentDepositLimit);

            return currentDepositLimit;
        }
        public async Task<DepositLimit> Disable(string customerId, string author)
        {
            var depositLimit = await _depositLimitRepository.GetActiveByCustomerId(customerId);
            if (depositLimit == null) throw new NotFoundException(DepositLimitMessages.DepositLimitNotFound);

            depositLimit.Disable(author);
            await _depositLimitRepository.Upsert(depositLimit);
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
