using FluentValidation;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Application.RequestMessages;
using Pinnacle.ResponsibleGaming.Application.RequestRules;

namespace Pinnacle.ResponsibleGaming.Application.RequestValidators
{
    public class SetDepositLimitValidator : AbstractValidator<SetDepositLimit>
    {
        public SetDepositLimitValidator()
        {
            RuleFor(x => x.CustomerId)
                .Must((x, request) => SetDepositLimitRules.StartDateCannotBeAPastDate(x.StartDate))
                .WithMessage(SetDepositLimitMessages.CustomerIdDoesNotExist);

            RuleFor(x => x.StartDate)
               .Must((x, request) => SetDepositLimitRules.StartDateCannotBeAPastDate(x.StartDate))
               .WithMessage(SetDepositLimitMessages.StartDateCannotBeAPastDate);

            RuleFor(x => x.Author)
            .NotEmpty()
            .WithMessage(SetDepositLimitMessages.AuthorMustBeProvided);
        }
    }
}
