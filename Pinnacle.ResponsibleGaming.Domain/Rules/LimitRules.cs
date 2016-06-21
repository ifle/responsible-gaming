using System;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Domain.Rules
{
    public static class LimitRules
    {
        public static bool LimitMustNotExist(Limit limit)
        {
            return limit==null;
        }
    }
}
