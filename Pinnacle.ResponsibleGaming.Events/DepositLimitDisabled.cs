using System;


namespace Pinnacle.ResponsibleGaming.Events
{
 
    public class DepositLimitDisabled: CustomerEvent
    {
        public string Author { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
