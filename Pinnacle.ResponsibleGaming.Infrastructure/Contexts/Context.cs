using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Pinnacle.ResponsibleGaming.Infrastructure.Configurations;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using System.Threading.Tasks;

namespace Pinnacle.ResponsibleGaming.Infrastructure.Contexts
{
    public class ResponsibleGamingContext : DbContext
    {
        public DbSet<Limit> Limits { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Event> Events { get; set; }

        public ResponsibleGamingContext()
            : base("name=MainSqlServer")
        {
            Database.SetInitializer<ResponsibleGamingContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new LimitConfiguration());
            modelBuilder.Configurations.Add(new LogConfiguration());
            modelBuilder.Configurations.Add(new EventConfiguration());

            base.OnModelCreating(modelBuilder);
        }        
    }
}
