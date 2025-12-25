using MfiManager.Middleware.Data.Entities.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlBranchVoucherTypeEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<BranchVoucherType> builder) {
            builder.ToTable("TBL_MFI_BRANCH_VOUCHER");
            builder.HasKey(bc => new { bc.BranchId, bc.VoucherTypeId });
            builder.Property(bc => bc.BranchId).HasColumnName("branch_id").IsRequired();
            builder.Property(bc => bc.VoucherTypeId).HasColumnName("voucher_id").IsRequired();
            builder.HasOne(bc => bc.Branch).WithMany(p => p.BranchVouchers).HasForeignKey(bc => bc.BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.VoucherType).WithMany(g => g.BranchVouchers).HasForeignKey(bc => bc.VoucherTypeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
