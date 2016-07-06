using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Pinnacle.ResponsibleGaming.Domain.Configurations;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Persistence.Contexts
{
    public  class MainContext: DbContext
    {
        public DbSet<Limit> Limits { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Event> Events { get; set; }

        public MainContext()
            : base("name=MainSqlServer")
        {
            Database.SetInitializer<MainContext>(null);
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
    }
}
