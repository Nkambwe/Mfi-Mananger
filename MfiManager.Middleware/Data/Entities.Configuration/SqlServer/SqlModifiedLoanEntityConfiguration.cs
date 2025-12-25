using MfiManager.Middleware.Data.Entities.Audits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlModifiedLoanEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<ModifiedLoan> builder) {
            builder.ToTable("TBL_MFI_MOD_LOAN");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.LoanNumber).HasColumnName("loan_number").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.InterestRate).HasColumnName("interest_rate").HasPrecision(9,2);
            builder.Property(p => p.Installments).HasColumnName("instalments");
            builder.Property(p => p.Principal).HasColumnName("principal").HasPrecision(9,2);
            builder.Property(p => p.Interest).HasColumnName("interest").HasPrecision(9,2);
            builder.Property(p => p.ApplicationDate).HasColumnName("application_date").IsRequired();
            builder.Property(p => p.AssesementDate).HasColumnName("assesement_date").IsRequired(false);
            builder.Property(p => p.ExpiryDate).HasColumnName("expiry_date").IsRequired(false);
            builder.Property(p => p.ApprovalLevel).HasColumnName("approval_level").IsRequired();
            builder.Property(p => p.IsRescheduled).HasColumnName("is_rescheduled").IsRequired();
            builder.Property(p => p.LoanStatus).HasColumnName("loan_statues").IsRequired();
            builder.Property(p => p.IsFrozeen).HasColumnName("is_frozeen");
            builder.Property(p => p.ProductId).HasColumnName("product_id").IsRequired();
            builder.Property(p => p.BranchId).HasColumnName("branch_id").IsRequired();
            builder.Property(p => p.CreditOfficerId).HasColumnName("officer_id").IsRequired();
            builder.Property(p => p.PersonId).HasColumnName("person_id").IsRequired(false);
            builder.Property(p => p.BusinessId).HasColumnName("business_id").IsRequired(false);
            builder.Property(p => p.MemberId).HasColumnName("member_id").IsRequired(false);
            builder.Property(p => p.GroupId).HasColumnName("group_id").IsRequired(false);
            builder.Property(p => p.CycleId).HasColumnName("cycle_id").IsRequired();
            builder.Property(p => p.LoanId).HasColumnName("loan_id").IsRequired();
            builder.Property(p => p.PurposeId).HasColumnName("purpose_id").IsRequired(false);
            builder.Property(p => p.FundId).HasColumnName("fund_id").IsRequired(false);
            builder.Property(p => p.Filter1Id).HasColumnName("filter_1_id").IsRequired(false);
            builder.Property(p => p.Filter2Id).HasColumnName("filter_2_id").IsRequired(false);
            builder.Property(p => p.Filter3Id).HasColumnName("filter_3_id").IsRequired(false);
            builder.Property(p => p.Filter4Id).HasColumnName("filter_4_id").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(bc => bc.Loan).WithMany(g => g.Modifications).HasForeignKey(bc => bc.LoanId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
