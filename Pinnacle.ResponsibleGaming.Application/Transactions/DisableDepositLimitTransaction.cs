using System.Data.Entity;


namespace Pinnacle.ResponsibleGaming.Application.Transactions
{
    public class DisableDepositLimitTransaction : DefaultTransaction
    {
        public DisableDepositLimitTransaction(DbContext dbContext)
            :base(dbContext)
        {
        }
    }
}
