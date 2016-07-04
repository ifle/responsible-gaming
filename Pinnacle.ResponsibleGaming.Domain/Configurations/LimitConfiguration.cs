using System.Data.Entity.ModelConfiguration;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Domain.Configurations
{
    public class LimitConfiguration : EntityTypeConfiguration<Limit>
    {
        public LimitConfiguration()
        {
            //Table
            ToTable("Limit");

            //Key
            HasKey(x => x.CustomerId);

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

            Property(t => t.CreationTime)
                .HasColumnType("datetime2")
                .IsRequired();


            //Ignore
            Ignore(x => x.Status);
            Ignore(x => x.IsRecurring);
        }
    }
}
