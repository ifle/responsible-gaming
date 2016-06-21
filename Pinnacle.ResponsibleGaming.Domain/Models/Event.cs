﻿using System;
using Newtonsoft.Json;

namespace Pinnacle.ResponsibleGaming.Domain.Models
{
    public class Event
    {
        public string Json { get; set; }
        public bool Sent { get; set; }

        public Event(object @event)
        {
            Json = JsonConvert.SerializeObject(@event);
        }

    }
}
