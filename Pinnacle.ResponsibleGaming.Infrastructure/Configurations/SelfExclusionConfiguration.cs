using System.Data.Entity.ModelConfiguration;
using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.Infrastructure.Configurations
{
    public class SelfExclusionConfiguration : EntityTypeConfiguration<SelfExclusion>
    {
        public SelfExclusionConfiguration()
        {
            //Map
            Map(x =>
                {
                    x.ToTable("Limit");
                    x.Requires("LimitTypeId").HasValue((int)LimitType.SelfExclusion);
                });

            //Key
            HasKey(x => x.CustomerId);

            //Properties
            Property(t => t.TimeInDays)
                .HasColumnName("Limit")
                .HasColumnType("decimal")
                .IsRequired();
        }
    }
}
