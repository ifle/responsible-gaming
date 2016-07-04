using System.Data.Entity.ModelConfiguration;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Domain.Configurations
{
    public class LogConfiguration : EntityTypeConfiguration<Log>
    {
        public LogConfiguration()
        {
            //Key
            HasKey(x => x.Id);

            //Properties
            Property(t => t.Action)
              .HasColumnType("nvarchar")
              .HasMaxLength(50)
              .IsRequired();

            Property(t => t.Limit)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(t => t.CustomerId)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(t => t.PeriodInDays)
              .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(t => t.StartDate)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(t => t.EndDate)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(t => t.Author)
                .HasColumnType("nvarchar")
                .HasMaxLength(20)
                .IsRequired();

            Property(t => t.CreationTime)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
