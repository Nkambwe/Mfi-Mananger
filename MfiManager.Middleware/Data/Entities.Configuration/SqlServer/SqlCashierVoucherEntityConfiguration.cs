using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlCashierVoucherEntityConfiguration {
        public static void Configure(EntityTypeBuilder<CashierVoucher> builder) {
            builder.ToTable("TBL_MFI_CASHIER_VOUCHER");
            builder.HasKey(bc => new { bc.CashierId, bc.VoucherId });
            builder.Property(bc => bc.CashierId).HasColumnName("cashier_id").IsRequired();
            builder.Property(bc => bc.VoucherId).HasColumnName("voucher_id").IsRequired();
            builder.HasOne(bc => bc.Cashier).WithMany(p => p.CashierVouchers).HasForeignKey(bc => bc.CashierId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Voucher).WithMany(g => g.CashierVouchers).HasForeignKey(bc => bc.VoucherId).OnDelete(DeleteBehavior.Cascade);
        }

    }

}
