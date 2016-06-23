using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Configurations;
using Pinnacle.ResponsibleGaming.Domain.Models;
using Pinnacle.ResponsibleGaming.Events;

namespace Pinnacle.ResponsibleGaming.Domain.Contexts
{
    public  class MainContext: DbContext
    {
        public DbSet<Limit> Limits { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Event> Event { get; set; }

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
            modelBuilder.Configurations.Add(new EventConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public Task<int> SaveChangesAsync(CustomerEvent customerEvent)
        {
            var @event = new Event(customerEvent);
            Event.Add(@event);
            return base.SaveChangesAsync();
        }
    }
}
