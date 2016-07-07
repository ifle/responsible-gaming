using FluentValidation.Attributes;
using Pinnacle.ResponsibleGaming.Application.Validators;

namespace Pinnacle.ResponsibleGaming.Application.Requests
{
    [Validator(typeof(SetDepositLimitValidator))]
    public  class DisableDepositLimit : CustomerRequest
    {
        public string Author { get; set; }
    }
}
