using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Pinnacle.ResponsibleGaming.Application.Contexts;
using Pinnacle.ResponsibleGaming.Infrastructure.Configurations;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Infrastructure.Contexts
{
    public  class Context: DbContext, IContext
    {
        private DbContextTransaction _dbContextTransaction;

        public DbSet<Limit> Limits { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Event> Events { get; set; }

        public Context()
            : base("name=MainSqlServer")
        {
            Database.SetInitializer<Context>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new LimitConfiguration());
            modelBuilder.Configurations.Add(new DepositLimitConfiguration());
            modelBuilder.Configurations.Add(new SelfExclusionConfiguration());
            modelBuilder.Configurations.Add(new LogConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public void BeginTransaction()
        {
            _dbContextTransaction = Database.BeginTransaction();
        }

        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            _dbContextTransaction = Database.BeginTransaction(isolationLevel);
        }

        public void Commit()
        {
            _dbContextTransaction.Commit();
        }
    }
}
