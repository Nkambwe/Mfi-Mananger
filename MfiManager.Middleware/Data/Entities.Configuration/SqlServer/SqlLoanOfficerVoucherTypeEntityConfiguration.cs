using MfiManager.Middleware.Data.Entities.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlLoanOfficerVoucherTypeEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<LoanOfficerVoucherType> builder) {
            builder.ToTable("TBL_MFI_LOANOFFICER_VOUCHER");
            builder.HasKey(bc => new { bc.LoanOfficerId, bc.VoucherTypeId });
            builder.Property(bc => bc.LoanOfficerId).HasColumnName("officer_id").IsRequired();
            builder.Property(bc => bc.VoucherTypeId).HasColumnName("voucher_id").IsRequired();
            builder.HasOne(bc => bc.LoanOfficer).WithMany(p => p.VoucherTypes).HasForeignKey(bc => bc.LoanOfficerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.VoucherType).WithMany(g => g.LoanOfficerVouchers).HasForeignKey(bc => bc.VoucherTypeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
