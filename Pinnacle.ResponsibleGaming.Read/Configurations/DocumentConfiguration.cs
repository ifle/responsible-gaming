using System.Data.Entity.ModelConfiguration;
using Pinnacle.ResponsibleGaming.Read.Models;

namespace Pinnacle.ResponsibleGaming.Read.Configurations
{
    public class DocumentConfiguration : EntityTypeConfiguration<Document>
    {
        public DocumentConfiguration()
        {
            //Key
            HasKey(x => x.Key);

            //Properties
            Property(t => t.Key)
              .HasColumnType("nvarchar")
              .HasMaxLength(50)
              .IsRequired();

            Property(t => t.Value)
                .HasColumnType("nvarchar(max)")
                .IsRequired();
        }
    }
}
