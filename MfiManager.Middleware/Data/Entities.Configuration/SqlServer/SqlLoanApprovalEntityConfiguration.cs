using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlLoanApprovalEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<LoanApproval> builder) {
            builder.ToTable("TBL_MFI_LOAN_APPROVAL");
            builder.HasKey(p => p.Id );
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ApprovalStage).HasColumnName("approval_level").IsRequired();
            builder.Property(p => p.ApprovalDate).HasColumnName("approval_date");
            builder.Property(p => p.ApproveAmount).HasColumnName("approve_amount").HasPrecision(9,2);
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.ApproverId).HasColumnName("loan_approver_id");
            builder.HasOne(bc => bc.Approver).WithMany(p => p.LoanApprovals).HasForeignKey(bc => bc.ApproverId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(p => p.IndividualLoanId).HasColumnName("individual_lnr_id").IsRequired(false);
            builder.HasOne(bc => bc.IndividualLoan).WithMany(p => p.LoanApprovals).HasForeignKey(bc => bc.IndividualLoanId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(p => p.BusinessLoanId).HasColumnName("business_lnr_id").IsRequired(false);
            builder.HasOne(bc => bc.BusinessLoan).WithMany(p => p.LoanApprovals).HasForeignKey(bc => bc.BusinessLoanId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(p => p.GroupLoanId).HasColumnName("group_lnr_id").IsRequired(false);
            builder.HasOne(bc => bc.GroupLoan).WithMany(p => p.LoanApprovals).HasForeignKey(bc => bc.GroupLoanId).OnDelete(DeleteBehavior.Cascade);
        }
    }
    
}
