using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Messages;
using Pinnacle.ResponsibleGaming.Domain._Common.Exceptions;
using Pinnacle.ResponsibleGaming.Domain.Models;
using Pinnacle.ResponsibleGaming.Domain.Queries;
using Pinnacle.ResponsibleGaming.Domain.Rules;

namespace Pinnacle.ResponsibleGaming.Domain.Validators
{
    public class DepositLimitValidator
    {
        private readonly DepositLimitQuery _depositLimitQuery;

        public DepositLimitValidator(DepositLimitQuery depositLimitQuery)
        {
            _depositLimitQuery = depositLimitQuery;
        }

        public async Task Validate(DepositLimit depositLimit)
        {
            var currentDepositLimit = await _depositLimitQuery.GetCurrentActive(depositLimit.CustomerId);
            if (!DepositLimitRules.NewDepositLimitMustBeMoreRestrictiveThanTheCurrentOne(depositLimit, currentDepositLimit)) { throw new ConflictException(DepositLimitMessages.DepositLimitMustBeMoreRestrictive);}
        }
    }
}
