using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Constants;
using Pinnacle.ResponsibleGaming.Domain.Contexts;
using Pinnacle.ResponsibleGaming.Domain._Common;
using Pinnacle.ResponsibleGaming.Domain.Expressions;
using Pinnacle.ResponsibleGaming.Domain.Models;
using Pinnacle.ResponsibleGaming.Domain.Rules;

namespace Pinnacle.ResponsibleGaming.Domain.Validators
{
    public class DepositLimitValidator
    {
        private readonly MainContext _mainDbContext;

        public DepositLimitValidator(MainContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task Validate(DepositLimit depositLimit)
        {
            var currentDepositLimit = await _mainDbContext.Limits.OfType<DepositLimit>().FirstOrDefaultAsync(LimitExpressions.CurrentActiveCustomerLimit(depositLimit.CustomerId));
            if (!LimitRules.LimitMustNotExist(currentDepositLimit)) throw new ConflictException(LimitMessages.ThereIsAnExitingLimitForThisCustomer); 
        }
    }
}
