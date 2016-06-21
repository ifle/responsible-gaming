using System;
using Newtonsoft.Json;
using Pinnacle.ResponsibleGaming.Events;

namespace Pinnacle.ResponsibleGaming.Domain.Models
{
    public class DepositLimit : Limit
    {
        public int AmountInCents { get; set; }

        public Log ToLog(string action)
        {
            return new Log
            {
                Action = action,
                CustomerId = CustomerId,
                Value = AmountInCents,
                PeriodInDays = PeriodInDays,
                StartDate = StartDate,
                EndDate = EndDate,
                Author = Author,
                CreationTime = CreationTime
            };
        }

        public DepositLimitSet ToDepositLimitSet()
        {
            return new DepositLimitSet
            {
                CustomerId = CustomerId,
                Amount = AmountInCents,
                PeriodInDays = PeriodInDays,
                StartDate = StartDate,
                EndDate = EndDate,
                Author = Author,
                CreationTime = CreationTime
            };
        }

        public DepositLimitDisabled ToDepositLimitDisabled()
        {
            return new DepositLimitDisabled
            {
                CustomerId = CustomerId
            };
        }
    }
}
