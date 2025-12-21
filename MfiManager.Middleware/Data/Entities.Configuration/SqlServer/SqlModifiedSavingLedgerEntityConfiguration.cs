using MfiManager.Middleware.Data.Entities.Audits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlModifiedSavingLedgerEntityConfiguration {

        public static void Configure(EntityTypeBuilder<ModifiedSavingLedger> builder) {
            builder.ToTable("TBL_MFI_MOD_SAVING_LEDGER");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.TransactionId).HasColumnName("transaction_id");
            builder.Property(p => p.TransactionCode).HasColumnName("trans_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.TransactionDate).HasColumnName("trans_date").IsRequired();
            builder.Property(p => p.Particulars).HasColumnName("particulars").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.Folio).HasColumnName("folio").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.TransType).HasColumnName("trans_type").IsRequired();
            builder.Property(p => p.OverdraftNumber).HasColumnName("overdraft_number").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.StandingOrder).HasColumnName("standing_order").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.TransAmount).HasColumnName("trans_amount").HasPrecision(9,2);
            builder.Property(p => p.AccountBalance).HasColumnName("acc_balance").HasPrecision(9,2);
            builder.Property(p => p.EntryDate).HasColumnName("entry_date");
            builder.Property(p => p.SavingAccountId).HasColumnName("saving_account_id");
            builder.Property(p => p.Cashier).HasColumnName("cashier").HasColumnType("NVARCHAR(10)");
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.ReasonId).HasColumnName("reason_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.SavingTransaction).WithMany(o => o.TransactionModifications).HasForeignKey(mp => mp.TransactionId);
            builder.HasOne(p => p.Reason).WithMany(e => e.ModifiedSavingTransactions).HasForeignKey(e => e.ReasonId);
        }
    }

}
