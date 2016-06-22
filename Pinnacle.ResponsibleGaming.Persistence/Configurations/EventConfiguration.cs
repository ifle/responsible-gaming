using System.Data.Entity.ModelConfiguration;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Persistence.Configurations
{
    public class EventConfiguration : EntityTypeConfiguration<Event>
    {
        public EventConfiguration()
        {
            //Key
            HasKey(x => x.Json);

            //Properties
            Property(t => t.Json)
                .HasColumnType("nvarchar")
                .HasMaxLength(1000)
                .IsRequired();

            Property(t => t.Sent)
               .HasColumnType("bit")
               .IsRequired();
        }
    }
}
