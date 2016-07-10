using FluentValidation;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Application.Messages;
using Pinnacle.ResponsibleGaming.Application.Rules;

namespace Pinnacle.ResponsibleGaming.Application.Validators
{
    public class SetDepositLimitValidator : AbstractValidator<SetDepositLimit>
    {
        public SetDepositLimitValidator()
        {
            RuleFor(x => x.CustomerId)
               .Must((x, request) => SetDepositLimitRules.AmountMustBePositive(x.Amount))
               .WithMessage(SetDepositLimitMessages.AmountMustBePositive);

            RuleFor(x => x.StartDate)
               .Must((x, request) => SetDepositLimitRules.StartDateCannotBeAPastDate(x.StartDate))
               .WithMessage(SetDepositLimitMessages.StartDateCannotBeAPastDate);

            RuleFor(x => x.Amount)
               .NotEmpty()
               .WithMessage(SetDepositLimitMessages.AuthorMustBeProvided);
        }
    }
}
