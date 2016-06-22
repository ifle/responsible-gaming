using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Constants;
using Pinnacle.ResponsibleGaming.Domain._Common;
using Pinnacle.ResponsibleGaming.Domain.Models;
using Pinnacle.ResponsibleGaming.Domain.Repositories;
using Pinnacle.ResponsibleGaming.Domain.Rules;

namespace Pinnacle.ResponsibleGaming.Domain.Validators
{
    public class DepositLimitValidator
    {
        private readonly IDepositLimitRepository _depositLimitRepository;

        public DepositLimitValidator(IDepositLimitRepository depositLimitRepository)
        {
            _depositLimitRepository = depositLimitRepository;
        }

        public async Task Validate(DepositLimit depositLimit)
        {
            var currentDepositLimit = await _depositLimitRepository.GetCurrentActiveCustomerLimit(depositLimit.CustomerId);
            if (!DepositLimitRules.DepositLimitMustBeMoreRestrictive(currentDepositLimit, depositLimit)) throw new ConflictException(DepositLimitMessages.DepositLimitMustBeMoreRestrictive);
            
        }
    }
}
