using MfiManager.Middleware.Data.Entities.Accounts.Ledgers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlCashLedgerEntityConfiguration {

        public static void Configure(EntityTypeBuilder<CashLedger> builder) {
            builder.ToTable("TBL_MFI_CASH_LEDGER");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.TransactionCode).HasColumnName("trans_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.LedgerAccount).HasColumnName("ledger_acc").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.PostedOn).HasColumnName("post_on").IsRequired();
            builder.Property(p => p.Description).HasColumnName("description").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.Provisional).HasColumnName("is_provisional");
            builder.Property(p => p.Debit).HasColumnName("debit").HasPrecision(9,2);
            builder.Property(p => p.Credit).HasColumnName("credit").HasPrecision(9,2);
            builder.Property(p => p.ExchangeAmount).HasColumnName("exchange_amount").HasPrecision(9,2);
            builder.Property(p => p.Balance).HasColumnName("balance").HasPrecision(9,2);
            builder.Property(p => p.CashAccountId).HasColumnName("cash_acc_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.CashAccount).WithMany(o => o.CashLedgerTransactions).HasForeignKey(mp => mp.CashAccountId);
        }
    }

}
