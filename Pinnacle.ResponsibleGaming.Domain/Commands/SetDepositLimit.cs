using System;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Domain.Commands
{
    public class SetDepositLimit
    {
        public string CustomerId { get; set; }
        public decimal Amount { get; set; }
        public int? PeriodInDays { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Author { get; set; }

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
                ModificationTime = DateTime.Now
            };
        }
    }
}
