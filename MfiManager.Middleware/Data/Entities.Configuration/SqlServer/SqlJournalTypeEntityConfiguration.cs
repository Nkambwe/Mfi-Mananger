using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlJournalTypeEntityConfiguration {
        public static void Configure(EntityTypeBuilder<JournalType> builder) {
             builder.ToTable("TBL_MFI_JOURNSL_TYPE");
             builder.HasKey(p => p.Id);
             builder.Property(p => p.Id).HasColumnName("id");
             builder.Property(p => p.Code).HasColumnName("voucher_number").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.JournalName).HasColumnName("journal_name").HasColumnType("NVARCHAR(MAX)").IsRequired();
             builder.Property(p => p.LedgerNumber).HasColumnName("ledger_number").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.PostingSeries).HasColumnName("posting_series");
             builder.Property(p => p.PostingType).HasColumnName("posting_type");
             builder.Property(p => p.AllowTaxDifference).HasColumnName("allow_tax_diff");
             builder.Property(p => p.RequireVoucher).HasColumnName("use_voucher");
             builder.Property(p => p.MultiCurrency).HasColumnName("is_multi_currency");
             builder.Property(p => p.Reference1).HasColumnName("reference_1");
             builder.Property(p => p.Reference2).HasColumnName("reference_2");
             builder.Property(p => p.Reference3).HasColumnName("reference_3");
             builder.Property(p => p.Reference4).HasColumnName("reference_4");
             builder.Property(p => p.Reference5).HasColumnName("reference_5");
             builder.Property(p => p.Reference6).HasColumnName("reference_6");
             builder.Property(p => p.System).HasColumnName("is_system");
             builder.Property(p => p.Active).HasColumnName("is_active");
             builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired();
             builder.Property(p => p.GeneralPostingId).HasColumnName("general_posting_id").IsRequired(false);
             builder.Property(p => p.BusinessPostingId).HasColumnName("business_posting_id").IsRequired(false);
             builder.Property(p => p.ReasonId).HasColumnName("reason_id").IsRequired(false);
             builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
             builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
             builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
             builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
             builder.HasOne(m => m.Reason).WithMany(o => o.Journals).HasForeignKey(mp => mp.ReasonId);
             builder.HasOne(m => m.GeneralPostingItem).WithMany(o => o.Journals).HasForeignKey(mp => mp.GeneralPostingId);
             builder.HasOne(m => m.BusinessPostingItem).WithMany(o => o.Journals).HasForeignKey(mp => mp.BusinessPostingId);
             builder.HasMany(m => m.CashierJournals).WithOne(o => o.Journal).HasForeignKey(mp => mp.JournalId);
             builder.HasMany(m => m.JournalTraxGroup).WithOne(o => o.JournalType).HasForeignKey(mp => mp.JournalTypeId);
        }
     }

}
