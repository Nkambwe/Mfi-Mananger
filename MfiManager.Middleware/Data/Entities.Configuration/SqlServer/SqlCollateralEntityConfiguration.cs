using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlCollateralEntityConfiguration {

        public static void Configure(EntityTypeBuilder<Collateral> builder) {
            builder.ToTable("TBL_MFI_COLLATERAL");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.OverdraftNumber).HasColumnName("overdraft").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.CollateralType).HasColumnName("collateral_type");
            builder.Property(p => p.Description).HasColumnName("description").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.CollateralValue).HasColumnName("collateral_value").HasPrecision(9,2);
            builder.Property(p => p.GuarantorId).HasColumnName("guarantor_id");
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Guarantor).WithMany(e => e.Collateral).HasForeignKey(e => e.GuarantorId);
            builder.HasMany(p => p.Images).WithOne(e => e.Collateral).HasForeignKey(e => e.CollateralId);
        }
    }

}
