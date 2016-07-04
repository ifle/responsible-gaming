using System;
using System.Globalization;
using FluentValidation.Attributes;
using Newtonsoft.Json;
using Pinnacle.ResponsibleGaming.Application.Validators;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Application.Requests
{
    [Validator(typeof(SetDepositLimitValidator))]
    public  class SetDepositLimit : CustomerRequest
    {
        public decimal Amount { get; set; }
        public int? PeriodInDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Author { get; set; }
        [JsonIgnore]
        public DateTime CreationTime { get; set; }

        public SetDepositLimit()
        {
            var now = DateTime.Now;
            StartDate = now;
            CreationTime = now;
        }

        public DepositLimit ToDepositLimit()
        {
            return new DepositLimit
                   {
                       CustomerId = CustomerId,
                       Amount = Amount,
                       PeriodInDays = PeriodInDays,
                       StartDate = StartDate,
                       EndDate = EndDate,
                       Author = Author,
                       CreationTime = CreationTime
                   };
        }

        public Log ToLog()
        {
            return new Log
            {
                Action = this.GetType().Name,
                CustomerId = CustomerId,
                Limit = Amount.ToString(CultureInfo.InvariantCulture),
                PeriodInDays = PeriodInDays?.ToString() ?? string.Empty,
                StartDate = StartDate.ToString("dd-MMM-yyyy HH:mm"),
                EndDate = EndDate?.ToString("dd-MMM-yyyy HH:mm") ?? string.Empty,
                Author = Author,
                CreationTime = CreationTime.ToString("dd-MMM-yyyy HH:mm")
            };
        }

    }
}
