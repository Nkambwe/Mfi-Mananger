using MfiManager.Middleware.Data.Entities.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlCashAccountEntityConfiguration {

        public static void Configure(EntityTypeBuilder<CashAccount> builder) {
            builder.ToTable("TBL_MFI_CASH_ACCOUNT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.LedgerNumber).HasColumnName("ledger_number").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.MinimumPayout).HasColumnName("min_payout").IsRequired();
            builder.Property(p => p.MaximumPayout).HasColumnName("max_payout").IsRequired();
            builder.Property(p => p.AllowMultiCurrency).HasColumnName("allow_mlti_currency");
            builder.Property(p => p.LedgerAccountId).HasColumnName("ledger_acc_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.LedgerAccount).WithMany(o => o.CashAccounts).HasForeignKey(mp => mp.LedgerAccountId);
            builder.HasMany(m => m.Cashiers).WithOne(o => o.CashAccount).HasForeignKey(mp => mp.CashAccountId);
            builder.HasMany(m => m.CashLedgerTransactions).WithOne(o => o.CashAccount).HasForeignKey(mp => mp.CashAccountId);
        }
    }

}
