using MfiManager.Middleware.Data.Entities.Audits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlModifiedShareLedgerEntityConfiguration {

        public static void Configure(EntityTypeBuilder<ModifiedShareTransactionLedger> builder) {
             builder.ToTable("TBL_MFI_MOD_SHARE_LEDGER");
             builder.HasKey(p => p.Id);
             builder.Property(p => p.Id).HasColumnName("id");
             builder.Property(p => p.Reference).HasColumnName("ref_number").HasColumnType("NVARCHAR(40)").IsRequired();
             builder.Property(p => p.TransactionDate).HasColumnName("trans_date");
             builder.Property(p => p.Payment).HasColumnName("payment_mode").IsRequired();
             builder.Property(p => p.ShareTransactionType).HasColumnName("trans_type").IsRequired();
             builder.Property(p => p.Shares).HasColumnName("shares").IsRequired();
             builder.Property(p => p.NorminalValue).HasColumnName("norm_value").HasPrecision(9,2).IsRequired();
             builder.Property(p => p.TransactionAmount).HasColumnName("amount").HasPrecision(9,2).IsRequired();
             builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired();
             builder.Property(p => p.RecordId).HasColumnName("record_id");
             builder.Property(p => p.AccountId).HasColumnName("share_acc_id");
             builder.Property(p => p.ModifiedReference).HasColumnName("mod_ref_number").HasColumnType("NVARCHAR(40)").IsRequired();
             builder.Property(p => p.ModifiedTransactionDate).HasColumnName("mod_trans_date");
             builder.Property(p => p.ModifiedPayment).HasColumnName("mod_payment_mode").IsRequired();
             builder.Property(p => p.MofifiedShareTransactionType).HasColumnName("mod_trans_type").IsRequired();
             builder.Property(p => p.ModifiedShares).HasColumnName("mod_shares").IsRequired();
             builder.Property(p => p.ModifiedNorminalValue).HasColumnName("mod_norm_value").HasPrecision(9,2).IsRequired();
             builder.Property(p => p.ModifiedTransactionAmount).HasColumnName("mod_amount").HasPrecision(9,2).IsRequired();
             builder.Property(p => p.ModifiedNotes).HasColumnName("mod_notes").HasColumnType("NVARCHAR(MAX)").IsRequired();
             builder.Property(p => p.ModifiedAccountId).HasColumnName("mod_share_acc_id");
             builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
             builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
             builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
             builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
             builder.HasOne(m => m.ShareTransaction).WithMany(o => o.Modifications).HasForeignKey(mp => mp.RecordId);
        }
    }

}
