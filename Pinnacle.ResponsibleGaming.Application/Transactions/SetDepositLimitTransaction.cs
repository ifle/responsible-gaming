using System.Data.Entity;


namespace Pinnacle.ResponsibleGaming.Application.Transactions
{
    public class SetDepositLimitTransaction : DefaultTransaction
    {
        public SetDepositLimitTransaction(DbContext dbContext)
            :base(dbContext)
        {
        }
    }
}
