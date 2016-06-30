using Pinnacle.ResponsibleGaming.Domain.Models;


namespace Pinnacle.ResponsibleGaming.Bus.Events
{
 
    public class DepositLimitDisabled: CustomerEvent
    {
        public DepositLimitDisabled (DepositLimit depositLimit)
        {
            CustomerId = depositLimit.CustomerId;
        }
    }
}
