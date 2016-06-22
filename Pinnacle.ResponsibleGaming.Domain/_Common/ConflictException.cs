using System;

namespace Pinnacle.ResponsibleGaming.Domain._Common
{
    public class ConflictException: Exception
    {
        public ConflictException(string message):base(message)
        {}
    }
}
