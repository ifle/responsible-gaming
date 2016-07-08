using FluentValidation;

namespace Pinnacle.ResponsibleGaming.Application.SetDepositLimit
{
    public class SetDepositLimitValidator : AbstractValidator<Request>
    {
        public SetDepositLimitValidator()
        {
            RuleFor(x => x.CustomerId)
               .Must((x, request) => SetDepositLimitRules.CustomerIdMustBeProvided(x.CustomerId))
               .WithMessage(Messages.CustomerIdMustBeProvided);

            RuleFor(x => x.CustomerId)
               .Must((x, request) => SetDepositLimitRules.AmountMustBePositive(x.Amount))
               .WithMessage(Messages.AmountMustBePositive);

            RuleFor(x => x.StartDate)
               .Must((x, request) => SetDepositLimitRules.StartDateCannotBeAPastDate(x.StartDate))
               .WithMessage(Messages.StartDateCannotBeAPastDate);

            RuleFor(x => x.Amount)
               .NotEmpty()
               .WithMessage(Messages.AuthorMustBeProvided);
        }
    }
}
