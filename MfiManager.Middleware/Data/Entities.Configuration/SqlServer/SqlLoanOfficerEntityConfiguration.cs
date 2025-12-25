using MfiManager.Middleware.Data.Entities.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {

    public class SqlLoanOfficerEntityConfiguration {
        public static void Configure(EntityTypeBuilder<LoanOfficer> builder) {
            builder.ToTable("TBL_MFI_LOAN_OFFICER");
            builder.HasKey(p => p.Id );
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Series).HasColumnName("series").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.PositionCode).HasColumnName("position_code").IsRequired();
            builder.Property(p => p.PositionName).HasColumnName("position_name").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(p => p.MaximumApprovalAmount).HasColumnName("max_limiy").HasPrecision(9,2).IsRequired();
            builder.Property(p => p.Active).HasColumnName("is_acivive");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.UserId).HasColumnName("user_id");
            builder.Property(p => p.LedgerAccountId).HasColumnName("ledger_id");
            builder.HasOne(bc => bc.LedgerAccount).WithMany(p => p.LoanOfficers).HasForeignKey(bc => bc.LedgerAccountId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(p => p.BranchId).HasColumnName("branch_id");
            builder.HasOne(bc => bc.Branch).WithMany(p => p.LoanOfficers).HasForeignKey(bc => bc.BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.Loans).WithOne(p => p.CreditOfficer).HasForeignKey(bc => bc.CreditOfficerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.LoanApprovals).WithOne(p => p.Approver).HasForeignKey(bc => bc.ApproverId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
