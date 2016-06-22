﻿using FluentValidation;
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