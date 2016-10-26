using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Messages;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Domain.Repositories;
using Pinnacle.ResponsibleGaming.Domain._Framework.Exceptions;

namespace Pinnacle.ResponsibleGaming.Domain.Services
{
    public class LimitService
    {
        private readonly ILimitRepository _limitRepository;
        private readonly ILogRepository _logRepository;

        public LimitService(ILimitRepository limitRepository, ILogRepository logRepository)
        {
            _limitRepository = limitRepository;
            _logRepository = logRepository;
        }

        public async Task<Limit> SetLimit(Limit limit)
        {
            // Retrieve current limit
            var currentDepositLimit = await _limitRepository.GetCustomerLimitByLimitType(limit.CustomerId, limit.LimitType);

            // Modify if it exists
            if (currentDepositLimit != null)
            {
                currentDepositLimit.Modify(limit.Value, limit.PeriodInDays, limit.EndDate, limit.Author);
            }
            // Create if it doesn't
            else
            {
                currentDepositLimit = limit;
            }
            await _limitRepository.AddOrUpdate(currentDepositLimit);

            //Log limit
            var log = new Log(limit);
            //_logRepository.Add(log);

            return currentDepositLimit;
        }
        public async Task<Limit> DisableLimit(string customerId, LimitType limitType, string author)
        {
            // Retrieve current limit
            var limit = await _limitRepository.GetCustomerLimitByLimitType(customerId, limitType);

            // Throw NotFound if it doesn't exist
            if (limit == null) throw new NotFoundException(LimitMessages.DepositLimitNotFound);

            // Disable limit
            limit.Disable(author);
            await _limitRepository.AddOrUpdate(limit);

            //Log limit
            var log = new Log(limit);
            await _logRepository.Add(log);

            return limit;
        }
    }
}
