using System;
using Newtonsoft.Json;


namespace Pinnacle.ResponsibleGaming.Events
{
    public class LimitSet
    {
        [JsonProperty(Order = 1)]
        public LimitType LimitType { get; set; }
        [JsonProperty(Order = 2)]
        public string CustomerId { get; set; }
        [JsonProperty(Order = 3)]
        public decimal Limit { get; set; }
        [JsonProperty(Order = 4)]
        public int? PeriodInDays { get; set; }
        [JsonProperty(Order = 5)]
        public DateTime StartDate { get; set; }
        [JsonProperty(Order = 6)]
        public DateTime? EndDate { get; set; }
    }
}
