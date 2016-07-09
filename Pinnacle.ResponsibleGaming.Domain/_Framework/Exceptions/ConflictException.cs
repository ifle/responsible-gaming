using System;

namespace Pinnacle.ResponsibleGaming.Domain._Framework.Exceptions
{
    public class ConflictException: Exception
    {
        public ConflictException(string message):base(message)
        {}
    }
}
