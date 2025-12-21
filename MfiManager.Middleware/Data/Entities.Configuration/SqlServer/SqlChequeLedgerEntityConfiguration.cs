using MfiManager.Middleware.Data.Entities.Accounts.Ledgers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlChequeLedgerEntityConfiguration {
        public static void Configure(EntityTypeBuilder<ChequeLedger> builder) {
             builder.ToTable("TBL_MFI_CHEQUE_LEDGER");
             builder.HasKey(p => p.Id);
             builder.Property(p => p.Id).HasColumnName("id");
             builder.Property(p => p.TransactionCode).HasColumnName("trans_code").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.ChequeNumber).HasColumnName("cheque_number").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.Folio).HasColumnName("folio").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.PostedOn).HasColumnName("post_on");
             builder.Property(p => p.Particulars).HasColumnName("particulars").HasColumnType("NVARCHAR(MAX)").IsRequired();
             builder.Property(p => p.ChequeStatus).HasColumnName("cheque_status");
             builder.Property(p => p.Amount).HasColumnName("amount").HasPrecision(9,2);
             builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
             builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
             builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
             builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
             builder.HasMany(m => m.BankTransactions).WithOne(o => o.ChequeTransaction).HasForeignKey(mp => mp.ChequeTransactionId);
        }
    }    

}
