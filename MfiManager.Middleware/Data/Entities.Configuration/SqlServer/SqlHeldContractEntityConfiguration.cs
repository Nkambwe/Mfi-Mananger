using MfiManager.Middleware.Data.Entities.Operations.Trade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlHeldContractEntityConfiguration {

        public static void Configure(EntityTypeBuilder<HeldContract> builder) {
            builder.ToTable("TBL_MFI_HELD_CONTRACT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ReasonId).HasColumnName("reason_id");
            builder.Property(p => p.VendorId).HasColumnName("vendor_id").IsRequired(false);
            builder.Property(p => p.SupplierId).HasColumnName("supplier_id").IsRequired(false);
            builder.Property(p => p.BranchId).HasColumnName("branch_id").IsRequired(false);
            builder.Property(p => p.ReleaseOn).HasColumnName("release_date");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Reason).WithMany(c => c.HeldContracts).HasForeignKey(bc => bc.ReasonId);
            builder.HasOne(p => p.Vendor).WithMany(c => c.HeldContracts).HasForeignKey(bc => bc.VendorId);
            builder.HasOne(p => p.Supplier).WithMany(c => c.HeldContracts).HasForeignKey(bc => bc.SupplierId);
            builder.HasOne(p => p.Branch).WithMany(c => c.Contracts).HasForeignKey(bc => bc.BranchId);
        }
    }
}
