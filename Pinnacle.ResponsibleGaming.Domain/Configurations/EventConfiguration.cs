using System.Data.Entity.ModelConfiguration;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Domain.Configurations
{
    public class EventConfiguration : EntityTypeConfiguration<Event>
    {
        public EventConfiguration()
        {
            //Key
            HasKey(x => x.Json);

            //Properties
            Property(t => t.EventId)
              .HasColumnType("uniqueidentifier")
              .HasColumnName("EventId")
              .IsRequired();

            Property(t => t.Name)
               .HasColumnType("nvarchar")
               .HasMaxLength(50)
               .IsRequired();

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
