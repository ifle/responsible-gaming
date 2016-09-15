using System;
using System.Collections.Generic;
using Pinnacle.ResponsibleGaming.Domain.Expressions;

namespace Pinnacle.ResponsibleGaming.Domain.Entities
{
    public abstract class Entity
    {
        public List<Event> Events { get; }
    }
}
