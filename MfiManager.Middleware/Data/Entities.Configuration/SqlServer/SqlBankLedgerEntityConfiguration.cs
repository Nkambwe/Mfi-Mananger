using MfiManager.Middleware.Data.Entities.Accounts.Ledgers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlBankLedgerEntityConfiguration {
        public static void Configure(EntityTypeBuilder<BankLedger> builder) {
             builder.ToTable("TBL_MFI_BANK_LEDGER");
             builder.HasKey(p => p.Id);
             builder.Property(p => p.Id).HasColumnName("id");
             builder.Property(p => p.TransactionCode).HasColumnName("trans_code").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.Folio).HasColumnName("folio").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.Voucher).HasColumnName("voucher_number").HasColumnType("NVARCHAR(10)").IsRequired(false);
             builder.Property(p => p.Ledger).HasColumnName("ledger_acc").HasColumnType("NVARCHAR(10)").IsRequired(false);
             builder.Property(p => p.Description).HasColumnName("description").HasColumnType("NVARCHAR(MAX)").IsRequired();
             builder.Property(p => p.PostedOn).HasColumnName("post_on");
             builder.Property(p => p.TransactionType).HasColumnName("trans_type");
             builder.Property(p => p.TransactionNature).HasColumnName("trans_nature");
             builder.Property(p => p.PaymentStatus).HasColumnName("pay_status");
             builder.Property(p => p.Debit).HasColumnName("debit").HasPrecision(9,2);
             builder.Property(p => p.Credit).HasColumnName("credit").HasPrecision(9,2);
             builder.Property(p => p.Balance).HasColumnName("balance").HasPrecision(9,2);
             builder.Property(p => p.Reconciled).HasColumnName("is_reconciled");
             builder.Property(p => p.Currency).HasColumnName("currency").HasColumnType("NVARCHAR(3)").IsRequired(false);
             builder.Property(p => p.TransactionDocumentId).HasColumnName("trans_doc_id").IsRequired(false);
             builder.Property(p => p.BankAccountId).HasColumnName("bank_acc_id").IsRequired(false);
             builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
             builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
             builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
             builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
             builder.HasOne(m => m.BankAccount).WithMany(o => o.BankTransaction).HasForeignKey(mp => mp.BankAccountId);
             builder.HasOne(m => m.Document).WithMany(o => o.BankLedgerTransactions).HasForeignKey(mp => mp.TransactionDocumentId);
             builder.HasOne(m => m.ChequeTransaction).WithMany(o => o.BankTransactions).HasForeignKey(mp => mp.ChequeTransactionId);
        }
    }
    

}
