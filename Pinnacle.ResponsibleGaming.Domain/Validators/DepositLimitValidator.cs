using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Contexts;
using Pinnacle.ResponsibleGaming.Domain.Expressions;
using Pinnacle.ResponsibleGaming.Domain.Messages;
using Pinnacle.ResponsibleGaming.Domain._Common.Exceptions;
using Pinnacle.ResponsibleGaming.Domain.Models;
using Pinnacle.ResponsibleGaming.Domain.Rules;

namespace Pinnacle.ResponsibleGaming.Domain.Validators
{
    public class DepositLimitValidator
    {
        private readonly MainContext _mainContext;

        public DepositLimitValidator(MainContext mainContext)
        {
            _mainContext = mainContext;
        }

        public async Task Validate(DepositLimit depositLimit)
        {
            var currentDepositLimit = await _mainContext.Limits.OfType<DepositLimit>().FirstOrDefaultAsync(LimitExpressions.CurrentActiveCustomerLimit<DepositLimit>(depositLimit.CustomerId));
            if (!DepositLimitRules.NewDepositLimitMustBeMoreRestrictiveThanTheCurrentOne(depositLimit, currentDepositLimit)) throw new ConflictException(DepositLimitMessages.DepositLimitMustBeMoreRestrictive);
        }
    }
}
