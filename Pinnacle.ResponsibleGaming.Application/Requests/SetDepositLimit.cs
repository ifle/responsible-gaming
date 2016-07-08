using System;
using FluentValidation.Attributes;
using Pinnacle.ResponsibleGaming.Application.Validators;
using Pinnacle.ResponsibleGaming.Domain.Entities;


namespace Pinnacle.ResponsibleGaming.Application.Requests
{
    [Validator(typeof(SetDepositLimitValidator))]
    public  class SetDepositLimit : CustomerRequest
    {
        public decimal Amount { get; set; }
        public int? PeriodInDays { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Author { get; set; }

        public DepositLimit ToDepositLimit()
        {
            return new DepositLimit(
                CustomerId,
                Amount,
                PeriodInDays,
                StartDate,
                EndDate,
                Author);
        }
    }
}
