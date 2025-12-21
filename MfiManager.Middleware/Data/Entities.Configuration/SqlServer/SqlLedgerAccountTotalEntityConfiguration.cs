using MfiManager.Middleware.Data.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlLedgerAccountTotalEntityConfiguration {
        public static void Configure(EntityTypeBuilder<LedgerAccountTotal> builder) {
            builder.ToTable("TBL_MFI_LEDGER_ACC_TOTAL");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.LedgerNumber).HasColumnName("ledger_number").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.LedgerName).HasColumnName("ledger_name").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.AccountClassification).HasColumnName("acc_classification");
            builder.Property(p => p.AccountCategory).HasColumnName("acc_category");
            builder.Property(p => p.AccountNature).HasColumnName("acc_nature");
            builder.Property(p => p.GroupIndex).HasColumnName("group_index");
            builder.Property(p => p.LedgerIndex).HasColumnName("ledger_index");
            builder.Property(p => p.TotalRange).HasColumnName("total_range").HasColumnType("NVARCHAR(40)");
            builder.Property(p => p.LedgerAccountTotalLabelId).HasColumnName("total_label_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.LedgerAccountTotalLabel).WithMany(o => o.LedgerAccountTotalLabels).HasForeignKey(mp => mp.LedgerAccountTotalLabelId);
        }
    }

}
