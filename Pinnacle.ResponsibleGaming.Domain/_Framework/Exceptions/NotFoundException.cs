using System;

namespace Pinnacle.ResponsibleGaming.Domain._Framework.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message):base(message)
        {}
    }
}
