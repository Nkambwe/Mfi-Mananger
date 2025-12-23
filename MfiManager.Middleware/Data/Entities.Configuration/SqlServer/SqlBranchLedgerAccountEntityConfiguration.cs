using MfiManager.Middleware.Data.Entities.Operations.Branches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlBranchLedgerAccountEntityConfiguration {

        public static void Configure(EntityTypeBuilder<BranchLedgerAccount> builder) {
            builder.ToTable("TBL_MFI_BRANCH_LEDGERACCOUNT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.DefaultNumber).HasColumnName("default_number").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.AssignedNumber).HasColumnName("assigned_number").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.AssignedLabel).HasColumnName("assigned_label").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.Suspend).HasColumnName("is_suspended");
            builder.Property(p => p.FromDate).HasColumnName("from_date").IsRequired(false);
            builder.Property(p => p.ToDate).HasColumnName("to_date").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.BranchId).HasColumnName("branch_id");
            builder.Property(p => p.LedgerAccountId).HasColumnName("legder_acc_id");
            builder.HasOne(m => m.Branch).WithMany(o => o.LedgerAccounts).HasForeignKey(mp => mp.BranchId);
            builder.HasOne(m => m.LedgerAccount).WithMany(o => o.BranchLedgerAccounts).HasForeignKey(mp => mp.LedgerAccountId);
        }
    }
    
    
}
