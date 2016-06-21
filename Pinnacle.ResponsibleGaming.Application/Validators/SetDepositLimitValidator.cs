using FluentValidation;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Application.Constants;
using Pinnacle.ResponsibleGaming.Application.Rules;

namespace Pinnacle.ResponsibleGaming.Application.Validators
{
    public class SetDepositLimitValidator : AbstractValidator<SetDepositLimit>
    {
        public SetDepositLimitValidator()
        {
            RuleFor(x => x.CustomerId)
                .Must((x, request) => SetDepositLimitRules.StartDateCannotBeAPastDate(x.StartDate))
                .WithMessage(ValidationMessages.CustomerIdDoesNotExist);

            RuleFor(x => x.StartDate)
               .Must((x, request) => SetDepositLimitRules.StartDateCannotBeAPastDate(x.StartDate))
               .WithMessage(ValidationMessages.StartDateCannotBeAPastDate);

            RuleFor(x => x.Author)
            .NotEmpty()
            .WithMessage(ValidationMessages.AuthorMustBeProvided);
        }
    }
}
