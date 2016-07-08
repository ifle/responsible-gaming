using System;
using FluentValidation.Attributes;
using Pinnacle.ResponsibleGaming.Domain.Entities;


namespace Pinnacle.ResponsibleGaming.Application.SetDepositLimit
{
    [Validator(typeof(SetDepositLimitValidator))]
    public  class Request : _Common.Request
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
