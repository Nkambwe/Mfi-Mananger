using MfiManager.Middleware.Data.Entities.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlCashierCashAccountEntityConfiguration {
        public static void Configure(EntityTypeBuilder<CashierCashAccount> builder) {
            builder.ToTable("TBL_MFI_CASHIER_CASH_ACCOUNT");
            builder.HasKey(bc => new { bc.CashierId, bc.CashAccountId });
            builder.Property(bc => bc.CashierId).HasColumnName("cashier_id").IsRequired();
            builder.Property(bc => bc.CashAccountId).HasColumnName("cash_account_id").IsRequired();
            builder.HasOne(bc => bc.Cashier).WithMany(p => p.CashAccounts).HasForeignKey(bc => bc.CashierId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.CashAccount).WithMany(g => g.Cashiers).HasForeignKey(bc => bc.CashAccountId).OnDelete(DeleteBehavior.Cascade);
        }

    }
}
