using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Messages;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Domain.Events;
using Pinnacle.ResponsibleGaming.Domain.Repositories;

namespace Pinnacle.ResponsibleGaming.Domain.Updaters
{
    public class DepositLimitUpdaters
    {
        private readonly IDepositLimitRepository _depositLimitRepository;

        public DepositLimitUpdaters(IDepositLimitRepository depositLimitRepository)
        {
            _depositLimitRepository = depositLimitRepository;
        }

        public async Task Handle(DepositLimitSet depositLimitSet)
        {
            var depositLimit = await _depositLimitRepository.GetActiveByCustomerId(depositLimitSet.CustomerId) ?? new DepositLimit();
            depositLimit.ApplyEvent(depositLimitSet);
            await _depositLimitRepository.Upsert(depositLimit);
        }
    }
}
