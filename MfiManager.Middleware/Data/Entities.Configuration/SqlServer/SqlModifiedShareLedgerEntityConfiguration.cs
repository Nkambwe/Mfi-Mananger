using MfiManager.Middleware.Data.Entities.Audits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlModifiedShareLedgerEntityConfiguration {

        public static void Configure(EntityTypeBuilder<ModifiedShareLedgerTransaction> builder) {
             builder.ToTable("TBL_MFI_MOD_SHARE_LEDGER");
             builder.HasKey(p => p.Id);
             builder.Property(p => p.Id).HasColumnName("id");
             builder.Property(p => p.TransactionId).HasColumnName("trans_id");
             builder.Property(p => p.TransactionCode).HasColumnName("ref_number").HasColumnType("NVARCHAR(40)").IsRequired();
             builder.Property(p => p.TransactionDate).HasColumnName("trans_date");
             builder.Property(p => p.Payment).HasColumnName("payment_mode").IsRequired();
             builder.Property(p => p.ShareTransactionType).HasColumnName("trans_type").IsRequired();
             builder.Property(p => p.Shares).HasColumnName("shares").IsRequired();
             builder.Property(p => p.NorminalValue).HasColumnName("norm_value").HasPrecision(9,2).IsRequired();
             builder.Property(p => p.TransactionAmount).HasColumnName("amount").HasPrecision(9,2).IsRequired();
             builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
             builder.Property(p => p.ShareAccountId).HasColumnName("share_acc_id");
             builder.Property(p => p.ReasonId).HasColumnName("reason_id");
             builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
             builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
             builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
             builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
             builder.HasOne(m => m.ShareTransaction).WithMany(o => o.Modifications).HasForeignKey(mp => mp.TransactionId);
             builder.HasOne(p => p.Reason).WithMany(e => e.ModifiedShareTransactions).HasForeignKey(e => e.ReasonId);
        }
    }

}
