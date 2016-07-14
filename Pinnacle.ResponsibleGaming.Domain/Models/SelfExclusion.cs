﻿using Newtonsoft.Json;


namespace Pinnacle.ResponsibleGaming.Domain.Models
{
    public class SelfExclusion : Limit
    {
        [JsonProperty(Order = 3)]
        public decimal TimeInDays { get; set; }
    }
}