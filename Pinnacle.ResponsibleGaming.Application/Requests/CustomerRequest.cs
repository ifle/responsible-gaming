using System;
using FluentValidation.Attributes;
using Newtonsoft.Json;
using Pinnacle.ResponsibleGaming.Application.RequestValidators;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Application.Requests
{
    public abstract class CustomerRequest
    {
        [JsonIgnore]
        public string CustomerId { get; set; }
    }
}
