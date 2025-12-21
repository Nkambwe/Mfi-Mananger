using MfiManager.Middleware.Data.Entities.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlVillageEntityConfiguration {
        public static void Configure(EntityTypeBuilder<Village> builder) {
            builder.ToTable("TBL_MFI_VILLAGE");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id");
            builder.Property(c => c.Code).HasColumnName("village_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(c => c.Name).HasColumnName("village_name").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(c => c.IsDeleted).HasColumnName("is_deleted");
            builder.Property(c => c.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(c => c.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(c => c.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(c => c.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(c => c.Individuals).WithOne(e => e.Village).HasForeignKey(e => e.VillageId);
            builder.HasMany(c => c.Members).WithOne(s => s.Village).HasForeignKey(s => s.VillageId);
            builder.HasMany(c => c.Guarantors).WithOne(s => s.Village).HasForeignKey(s => s.VillageId);
            builder.HasMany(c => c.IndividualArchives).WithOne(s => s.Village).HasForeignKey(s => s.VillageId);
        }
    }
}
