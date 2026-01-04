using MfiManager.Middleware.Data.Entities.Operations.Saving;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlOverdraftGuaranteeEntityConfiguration {

        public static void Configure(EntityTypeBuilder<OverdraftGuarantee> builder) {
            builder.ToTable("TBL_MFI_MOD_OVERDRAFT_GUARANTEE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.CollateralType).HasColumnName("col_type");
            builder.Property(p => p.Percentage).HasColumnName("per_rate").HasPrecision(9,2);
            builder.Property(p => p.AmountGuaranteed).HasColumnName("amount_guar").HasPrecision(9,2);
            builder.Property(p => p.CollateralValue).HasColumnName("cal_value").HasPrecision(9,2);
            builder.Property(p => p.CollateralDescription).HasColumnName("cal_descr").HasColumnType("NVARCHAR(250)").IsRequired();
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Guarantor).WithMany(e => e.Overdrafts).HasForeignKey(e => e.OverdraftId);
            builder.HasOne(p => p.Overdraft).WithMany(e => e.Guarantees).HasForeignKey(e => e.OverdraftId);
            builder.HasMany(p => p.Modifications).WithOne(e => e.OverdraftGuarantee).HasForeignKey(e => e.OverdraftId);
        }
    }

}
