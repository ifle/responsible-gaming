using System.Data.Entity.ModelConfiguration;
using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.Infrastructure.Configurations
{
    public class LimitConfiguration : EntityTypeConfiguration<Limit>
    {
        public LimitConfiguration()
        {
            //Table
            ToTable("Limit");

            //Key
            HasKey(x => x.LimitId);

            //Properties
            Property(t => t.CustomerId)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
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

            //Ignore
            Ignore(x => x.Status);
            Ignore(x => x.IsRecurring);
            Ignore(x => x.Events);
        }
    }
}
