using System;
using Newtonsoft.Json;


namespace Pinnacle.ResponsibleGaming.Events
{
    public class DepositLimitSet
    {
        [JsonProperty(Order = 1)]
        public string CustomerId { get; set; }
        [JsonProperty(Order = 2)]
        public decimal Amount { get; set; }
        [JsonProperty(Order = 3)]
        public int? PeriodInDays { get; set; }
        [JsonProperty(Order = 4)]
        public DateTime StartDate { get; set; }
        [JsonProperty(Order = 5)]
        public DateTime? EndDate { get; set; }
        [JsonProperty(Order = 6)]
        public string Author { get; set; }
        [JsonProperty(Order = 7)]
        public DateTime ModificationTime { get; set; }
    }
}
