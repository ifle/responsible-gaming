using System.Data.Entity.ModelConfiguration;
using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.Infrastructure.Configurations
{
    public class EventConfiguration : EntityTypeConfiguration<Event>
    {
        public EventConfiguration()
        {
            //Table
            ToTable("Event");

            //Key
            HasKey(x => x.Id);

            //Properties
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
