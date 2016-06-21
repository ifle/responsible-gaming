using System;
using Newtonsoft.Json;

namespace Pinnacle.ResponsibleGaming.Events
{
 
    public class DepositLimitSet
    {
        public string CustomerId { get; set; }
        public decimal Amount { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? PeriodInDays { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? StartDate { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? EndDate { get; set; }
        public string Author { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
