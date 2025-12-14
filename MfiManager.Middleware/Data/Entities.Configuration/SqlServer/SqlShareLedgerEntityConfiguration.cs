using MfiManager.Middleware.Data.Entities.Operations.Shares;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlShareLedgerEntityConfiguration {

        public static void Configure(EntityTypeBuilder<ShareTransactionLedger> builder) {
            builder.ToTable("TBL_MFI_SHARE_LEDGER");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Reference).HasColumnName("ref_number").HasColumnType("NVARCHAR(40)").IsRequired();
            builder.Property(p => p.TransactionDate).HasColumnName("trans_date");
            builder.Property(p => p.Payment).HasColumnName("payment_mode").IsRequired();
            builder.Property(p => p.ShareTransactionType).HasColumnName("trans_type").IsRequired();
            builder.Property(p => p.Shares).HasColumnName("shares").IsRequired();
            builder.Property(p => p.TransactionAmount).HasColumnName("amount").HasPrecision(9,2).IsRequired();
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.ShareAccountId).HasColumnName("share_acc_id");
            builder.Property(p => p.ShareValueId).HasColumnName("share_value_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.ShareAccount).WithMany(o => o.ShareTransactions).HasForeignKey(mp => mp.ShareAccountId);
            builder.HasOne(m => m.ShareValue).WithMany(o => o.ShareTransactions).HasForeignKey(mp => mp.ShareValueId);
            builder.HasMany(m => m.Modifications).WithOne(o => o.ShareTransaction).HasForeignKey(mp => mp.RecordId);
        }
    }

}
