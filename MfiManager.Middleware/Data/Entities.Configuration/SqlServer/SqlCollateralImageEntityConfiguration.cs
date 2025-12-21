using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlCollateralImageEntityConfiguration {

        public static void Configure(EntityTypeBuilder<CollateralImage> builder) {
            builder.ToTable("TBL_MFI_COLLATERAL_IMAGE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FileName).HasColumnName("file_name").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.CollateralId).HasColumnName("collateral_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.HasOne(p => p.Collateral).WithMany(e => e.Images).HasForeignKey(e => e.CollateralId);
        }
    }

}
