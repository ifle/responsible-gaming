using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Messages;
using Pinnacle.ResponsibleGaming.Domain.Models;
using Pinnacle.ResponsibleGaming.Domain.Queries;
using Pinnacle.ResponsibleGaming.Domain._Common.Exceptions;

namespace Pinnacle.ResponsibleGaming.Domain.Services
{
    public class DepositLimitService
    {
        private readonly DbContext _dbContext;
        private readonly DepositLimitQuery _depositLimitQuery;

        public DepositLimitService(DbContext dbContext, DepositLimitQuery depositLimitQuery)
        {
            _dbContext = dbContext;
            _depositLimitQuery = depositLimitQuery;
        }

        public async Task<DepositLimit> SetDepositLimit(DepositLimit depositLimit)
        {
            var currentDepositLimit = await GetDepositLimit(depositLimit.CustomerId);
            if (currentDepositLimit != null)
            {
                currentDepositLimit.Modify(depositLimit);
            }
            else
            {
                currentDepositLimit = depositLimit;
            }

            _dbContext.Set<Limit>().AddOrUpdate(currentDepositLimit);
            await _dbContext.SaveChangesAsync();

            return currentDepositLimit;
        }
        public async Task<DepositLimit> DisableDepositLimit(string customerId, string author)
        {
            var depositLimit = await _depositLimitQuery.GetActiveLimitByCustomerId(customerId);
            if (depositLimit == null) throw new NotFoundException(DepositLimitMessages.DepositLimitNotFound);

            depositLimit.Disable(author);
            _dbContext.Set<Limit>().AddOrUpdate(depositLimit);
            return depositLimit;
        }
        public async Task<DepositLimit> GetDepositLimit(string customerId)
        {
            //Check if customer exists
            if (false) throw new NotFoundException(DepositLimitMessages.CustomerNotFound);

            var depositLimit = await _depositLimitQuery.GetActiveLimitByCustomerId(customerId);
            return depositLimit;
        }
    }
}
