using System;
using FluentValidation.Attributes;
using Newtonsoft.Json;
using Pinnacle.ResponsibleGaming.Application.Validators;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Application.Requests
{
    [Validator(typeof(SetDepositLimitValidator))]
    public  class DisableDepositLimit : CustomerRequest
    {
        public string Author { get; set; }
        [JsonIgnore]
        public DateTime CreationTime { get; set; }

        public DisableDepositLimit()
        {
            var now = DateTime.Now;
            CreationTime = now;
        }


        public Log ToLog()
        {
            return new Log
            {
                Action = this.GetType().Name,
                CustomerId = CustomerId,
                Limit = string.Empty,
                PeriodInDays = string.Empty,
                StartDate = string.Empty,
                EndDate = string.Empty,
                Author = Author,
                CreationTime = CreationTime.ToShortDateString()
            };
        }
    }
}
