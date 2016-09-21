using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Pinnacle.ResponsibleGaming.Infrastructure.Configurations;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using System.Reflection;
using log4net;

namespace Pinnacle.ResponsibleGaming.Infrastructure.Contexts
{
    public class MainContext : DbContext
    {
        private ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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
            modelBuilder.Configurations.Add(new LogConfiguration());
            modelBuilder.Configurations.Add(new EventConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync()
        {
            var domainEventEntities = ChangeTracker.Entries<Entity>()
           .Select(po => po.Entity)
           .Where(po => po.Events.Any())
           .ToArray();

            foreach (var entity in domainEventEntities)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();
                foreach (var @event in events)
                {
                    Events.Add(@event);
                    //Log into Splunk
                    _log.Info(SerializeAsKeyValues(@event));
                }
            }

            return base.SaveChangesAsync();
        }

        private static string SerializeAsKeyValues(object obj)
        {
            var type = obj.GetType().Name;
            var serializedRequest = JsonConvert.SerializeObject(obj);
            serializedRequest = serializedRequest.Replace(":", "=").Replace("\"", "").Replace("{", "").Replace("}", "").Replace(",", ", ");
            serializedRequest = "Request=" + type.Replace("Request", "") + ", " + serializedRequest;
            return serializedRequest;
        }
    }
}
