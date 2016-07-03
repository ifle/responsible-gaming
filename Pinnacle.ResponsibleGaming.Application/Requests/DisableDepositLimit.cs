using System;
using FluentValidation.Attributes;
using Newtonsoft.Json;
using Pinnacle.ResponsibleGaming.Application.Validators;
using Pinnacle.ResponsibleGaming.Events;

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


        public DepositLimitSet ToDepositLimitDisabled()
        {
            return new DepositLimitSet
            {
                CustomerId = CustomerId,
                Author = Author,
                CreationTime = CreationTime
            };
        }

    }
}
