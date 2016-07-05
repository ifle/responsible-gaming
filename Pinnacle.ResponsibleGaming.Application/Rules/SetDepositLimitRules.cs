using System;
using System.Threading.Tasks;
using FluentValidation.Validators;
using Pinnacle.ResponsibleGaming.Domain.Queries;
using Pinnacle.ResponsibleGaming.Domain.Rules;

namespace Pinnacle.ResponsibleGaming.Application.Rules
{
    public class SetDepositLimitRules
    {
        private readonly DepositLimitQuery _depositLimitQuery;

        public SetDepositLimitRules(DepositLimitQuery depositLimitQuery)
        {
            _depositLimitQuery = depositLimitQuery;
        }
        public  bool CustomerIdMustBeProvided(string customerId)
        {
            return !string.IsNullOrEmpty(customerId);
        }
        public  bool StartDateCannotBeAPastDate(DateTime? startDate)
        {
            return !startDate.HasValue || (startDate.Value - DateTime.Now).Days >= 0;
        }
        public  bool AmountMustBePositive(decimal amount)
        {
            return amount > 0;
        }
        public async Task<bool> NewLimitMustBeMoreRestrictiveThanTheCurrentOne(string customerId, decimal newAmount)
        {
            var currentDepositLimit = await _depositLimitQuery.GetByCustomerId(customerId);
            if (currentDepositLimit == null) return true;
            return DepositLimitRules.NewLimitMustBeMoreRestrictiveThanTheCurrentOne(newAmount,
                currentDepositLimit.Amount);
        }
        public async Task<bool> NewPeriodMustBeMoreRestrictiveThanTheCurrentOne(string customerId, int? newPeriodInDays)
        {
            var currentDepositLimit = await _depositLimitQuery.GetByCustomerId(customerId);
            if (currentDepositLimit == null) return true;
            return DepositLimitRules.NewPeriodMustBeMoreRestrictiveThanTheCurrentOne(newPeriodInDays,
                currentDepositLimit.PeriodInDays);
        }
    }
}
