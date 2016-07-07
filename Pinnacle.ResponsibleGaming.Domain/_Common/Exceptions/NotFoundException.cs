using System;

namespace Pinnacle.ResponsibleGaming.Domain._Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message):base(message)
        {}
    }
}
