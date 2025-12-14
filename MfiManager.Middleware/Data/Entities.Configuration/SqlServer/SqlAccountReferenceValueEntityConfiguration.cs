using MfiManager.Middleware.Data.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlAccountReferenceValueEntityConfiguration {

        public static void Configure(EntityTypeBuilder<AccountReferenceValue> builder) {
            builder.ToTable("TBL_MFI_ACC_REFERENCE_VALUE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("value_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.Description).HasColumnName("value_description").HasColumnType("NVARCHAR(40)").IsRequired();
            builder.Property(p => p.Suspend).HasColumnName("is_suspended");
            builder.Property(p => p.Start).HasColumnName("start_date").IsRequired(false);
            builder.Property(p => p.End).HasColumnName("end_date").IsRequired(false);
            builder.Property(p => p.AllowManualEntry).HasColumnName("allow_manual");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.AccountReference).WithMany(o => o.ReferenceValues).HasForeignKey(mp => mp.ReferenceId);
            builder.HasMany(m => m.SupplierReferences).WithOne(o => o.ReferenceValue).HasForeignKey(mp => mp.ReferenceValueId);
            builder.HasMany(m => m.BranchReferences).WithOne(o => o.ReferenceValue).HasForeignKey(mp => mp.ReferenceValueId);
            builder.HasMany(m => m.VendorReferences).WithOne(o => o.ReferenceValue).HasForeignKey(mp => mp.ReferenceValueId);
            
        }
    }
}
