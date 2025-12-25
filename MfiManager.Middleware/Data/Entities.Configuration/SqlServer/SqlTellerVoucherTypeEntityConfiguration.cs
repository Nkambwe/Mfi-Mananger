using MfiManager.Middleware.Data.Entities.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlTellerVoucherTypeEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<TellerVoucherType> builder) {
            builder.ToTable("TBL_MFI_TELLER_VOUCHER");
            builder.HasKey(bc => new { bc.TellerId, bc.VoucherTypeId });
            builder.Property(bc => bc.TellerId).HasColumnName("branch_id").IsRequired();
            builder.Property(bc => bc.VoucherTypeId).HasColumnName("voucher_id").IsRequired();
            builder.HasOne(bc => bc.Teller).WithMany(p => p.VoucherTypes).HasForeignKey(bc => bc.TellerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.VoucherType).WithMany(g => g.TellerVouchers).HasForeignKey(bc => bc.VoucherTypeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
