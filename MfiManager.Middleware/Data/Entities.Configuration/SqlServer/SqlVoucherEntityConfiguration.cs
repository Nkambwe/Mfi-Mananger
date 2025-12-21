using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlVoucherEntityConfiguration {
        public static void Configure(EntityTypeBuilder<Voucher> builder) {
            builder.ToTable("TBL_MFI_VOUCHER");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.TransactionCode).HasColumnName("trans_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.PostedOn).HasColumnName("trans_date").IsRequired();
            builder.Property(p => p.Particulars).HasColumnName("particulars").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.Folio).HasColumnName("folio").IsRequired();
            builder.Property(p => p.VoucherNumber).HasColumnName("voucher_number").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.RelatesTo).HasColumnName("relates_to").HasColumnType("NVARCHAR(20)").IsRequired();
            builder.Property(p => p.CashRef).HasColumnName("cash_ref").IsRequired();
            builder.Property(p => p.Payment).HasColumnName("pay_mode");
            builder.Property(p => p.PaymentStatus).HasColumnName("pay_status");
            builder.Property(p => p.Debit).HasColumnName("credit").HasPrecision(9,2);
            builder.Property(p => p.Credit).HasColumnName("debit").HasPrecision(9,2);
            builder.Property(p => p.Discount).HasColumnName("discount").HasPrecision(9,2);
            builder.Property(p => p.Authorized).HasColumnName("authorized_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.Cashier).HasColumnName("cash_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.GeneralLedgerTransactionId).HasColumnName("ledger_id").IsRequired(false);
            builder.Property(p => p.GeneralJournalTransactionId).HasColumnName("journal_id").IsRequired(false);
            builder.Property(p => p.TransactionDocumentId).HasColumnName("document_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.GeneralJournalTransaction).WithMany(o => o.VoucherTransactions).HasForeignKey(mp => mp.GeneralJournalTransactionId);
            builder.HasOne(m => m.GeneralLedgerTransaction).WithMany(o => o.VoucherTransactions).HasForeignKey(mp => mp.GeneralLedgerTransactionId);
            builder.HasOne(m => m.TransactionDocument).WithMany(o => o.VoucherTransactions).HasForeignKey(mp => mp.TransactionDocumentId);
        }
    }

}
