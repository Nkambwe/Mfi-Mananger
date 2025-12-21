using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlRecurringItemEntityConfiguration {
        public static void Configure(EntityTypeBuilder<RecurringItem> builder) {
             builder.ToTable("TBL_MFI_RECURRING_ITEM");
             builder.HasKey(p => p.Id);
             builder.Property(p => p.Id).HasColumnName("id");
             builder.Property(p => p.Code).HasColumnName("item_code").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.Name).HasColumnName("item_name").HasColumnType("NVARCHAR(MAX)").IsRequired();
             builder.Property(p => p.Starts).HasColumnName("start_date");
             builder.Property(p => p.Ends).HasColumnName("end_date").IsRequired(false);
             builder.Property(p => p.Amount).HasColumnName("amounts").HasPrecision(9,2);
             builder.Property(p => p.Every).HasColumnName("interval");
             builder.Property(p => p.PostingType).HasColumnName("posting_type");
             builder.Property(p => p.Auto).HasColumnName("is_auto");
             builder.Property(p => p.PostingLedger).HasColumnName("posting_ledger").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.AgainstLedger).HasColumnName("against_ledger").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
             builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
             builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
             builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
             builder.Property(p => p.BranchId).HasColumnName("branch_id").IsRequired(false);
             builder.HasOne(m => m.Branch).WithMany(o => o.RecurringItems).HasForeignKey(mp => mp.BranchId); 
        }
    }

}
