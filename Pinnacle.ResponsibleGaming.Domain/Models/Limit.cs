using System;
using Newtonsoft.Json;
using Pinnacle.ResponsibleGaming.Domain.Expressions;

namespace Pinnacle.ResponsibleGaming.Domain.Models
{
    public abstract class Limit
    {
        [JsonProperty(Order = 1)]
        public int LimitId { get; set; }
        [JsonProperty(Order = 2)]
        public string CustomerId { get; set; }
        [JsonProperty(Order = 4)]
        public int? PeriodInDays { get; set; }
        [JsonProperty(Order = 5)]
        public DateTime StartDate { get; set; }
        [JsonProperty(Order = 6)]
        public DateTime? EndDate { get; set; }
        [JsonProperty(Order = 7)]
        public string Author { get; set; }
        [JsonProperty(Order = 8)]
        public DateTime ModificationTime { get; set; }
        [JsonProperty(Order = 9)]
        public LimitStatus Status => LimitExpressions.IsActiveLimit<Limit>().Compile()(this) ? LimitStatus.Active : LimitStatus.Expired;
        [JsonProperty(Order = 10)]
        public bool IsRecurring => PeriodInDays.HasValue;
    }
}
