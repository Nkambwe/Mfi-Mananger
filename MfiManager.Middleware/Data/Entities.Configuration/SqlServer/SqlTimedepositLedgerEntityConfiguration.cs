using MfiManager.Middleware.Data.Entities.Operations.Timedeposit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlTimedepositLedgerEntityConfiguration {

        public static void Configure(EntityTypeBuilder<TimedepositLedger> builder) {
            builder.ToTable("TBL_MFI_TIMEDEPOSIT_LEDGER");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.TransactionCode).HasColumnName("trans_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.TransactionDate).HasColumnName("trans_date").IsRequired();
            builder.Property(p => p.Particulars).HasColumnName("particulars").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.Folio).HasColumnName("folio").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.Payment).HasColumnName("payment_type").IsRequired();
            builder.Property(p => p.TransAmount).HasColumnName("trans_amount").HasPrecision(9,2);
            builder.Property(p => p.EntryDate).HasColumnName("entry_date");
            builder.Property(p => p.TimedepositAccountId).HasColumnName("timedeposit_account_id");
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.TimedepositAccount).WithMany(o => o.TimedepositTransactions).HasForeignKey(mp => mp.TimedepositAccountId);
            builder.HasMany(m => m.ModifiedTimedepositTransactions).WithOne(o => o.TimedepositTransaction).HasForeignKey(mp => mp.TransactionId);
        }
    }
}
