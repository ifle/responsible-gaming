using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.ModelConfiguration;
using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.Domain.Configurations
{
    public class LogConfiguration : EntityTypeConfiguration<Log>
    {
        public LogConfiguration()
        {
            //Key
            HasKey(x => x.LogId);

            //Properties
            Property(t => t.LimitId)
              .HasColumnType("int")
              .IsRequired();

            Property(t => t.CustomerId)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(t => t.LimitTypeId)
               .HasColumnType("int")
               .IsRequired();

            Property(t => t.Limit)
               .HasColumnName("Limit")
               .HasColumnType("decimal")
               .IsRequired();

            Property(t => t.PeriodInDays)
                .HasColumnType("int")
                .IsOptional();

            Property(t => t.StartDate)
                .HasColumnType("datetime2")
                .IsRequired();

            Property(t => t.EndDate)
                .HasColumnType("datetime2")
                .IsOptional();

            Property(t => t.Author)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(t => t.ModificationTime)
                .HasColumnType("datetime2")
                .IsRequired();
        }
    }
}
