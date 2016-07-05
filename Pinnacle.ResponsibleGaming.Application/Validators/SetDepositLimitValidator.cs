using FluentValidation;
using Pinnacle.ResponsibleGaming.Application.Requests;
using Pinnacle.ResponsibleGaming.Application.Messages;
using Pinnacle.ResponsibleGaming.Application.Rules;
using Pinnacle.ResponsibleGaming.Domain.Contexts;
using Pinnacle.ResponsibleGaming.Domain.Messages;
using Pinnacle.ResponsibleGaming.Domain.Queries;

namespace Pinnacle.ResponsibleGaming.Application.Validators
{
    public class SetDepositLimitValidator : AbstractValidator<SetDepositLimit>
    {
        public SetDepositLimitValidator()
        {
            var setDepositLimitRules = new SetDepositLimitRules(new DepositLimitQuery(new MainContext()));

            RuleFor(x => x.CustomerId)
               .Must((x, request) => setDepositLimitRules.StartDateCannotBeAPastDate(x.StartDate))
               .WithMessage(SetDepositLimitMessages.CustomerIdDoesNotExist);

            RuleFor(x => x.CustomerId)
               .Must((x, request) => setDepositLimitRules.AmountMustBePositive(x.Amount))
               .WithMessage(SetDepositLimitMessages.AmountMustBePositive);

            RuleFor(x => x.StartDate)
               .Must((x, request) => setDepositLimitRules.StartDateCannotBeAPastDate(x.StartDate))
               .WithMessage(SetDepositLimitMessages.StartDateCannotBeAPastDate);

            RuleFor(x => x.Amount)
               .NotEmpty()
               .WithMessage(SetDepositLimitMessages.AuthorMustBeProvided);

            //RuleFor(x => x)
            //   .MustAsync((x, request) => setDepositLimitRules.NewLimitMustBeMoreRestrictiveThanTheCurrentOne(x.CustomerId, x.Amount))
            //   .WithMessage(DepositLimitMessages.LimitMustBeMoreRestrictiveThanTheCurrentOne);

            //RuleFor(x => x)
            //   .MustAsync((x, request) => setDepositLimitRules.NewPeriodMustBeMoreRestrictiveThanTheCurrentOne(x.CustomerId, x.PeriodInDays))
            //   .WithMessage(DepositLimitMessages.PeriodMustBeMoreRestrictiveThanTheCurrentOne);
        }
    }
}
