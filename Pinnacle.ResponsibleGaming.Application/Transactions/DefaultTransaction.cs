using System;
using System.Data.Entity;


namespace Pinnacle.ResponsibleGaming.Application.Transactions
{
    public abstract class DefaultTransaction
    {
        private readonly DbContext _dbContext;
        private DbContextTransaction _dbContextTransaction;

        protected DefaultTransaction(DbContext dbContext)
        {
            _dbContext = dbContext;        
        }

        public void Begin()
        {
            _dbContextTransaction = _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _dbContextTransaction.Commit();
        }
    }
}
