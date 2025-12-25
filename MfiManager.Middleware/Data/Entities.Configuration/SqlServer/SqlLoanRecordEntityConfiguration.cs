using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlLoanRecordEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<LoanRecord> builder) {
            builder.ToTable("TBL_MFI_LOAN");
            builder.HasKey(p => p.Id );
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
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(bc => bc.Product).WithMany(p => p.Loans).HasForeignKey(bc => bc.ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Branch).WithMany(g => g.Loans).HasForeignKey(bc => bc.BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.CreditOfficer).WithMany(p => p.Loans).HasForeignKey(bc => bc.CreditOfficerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Individual).WithMany(g => g.Loans).HasForeignKey(bc => bc.PersonId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Business).WithMany(p => p.Loans).HasForeignKey(bc => bc.BusinessId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Member).WithMany(g => g.Loans).HasForeignKey(bc => bc.MemberId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Purpose).WithMany(p => p.Loans).HasForeignKey(bc => bc.PurposeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Filter1).WithMany(g => g.Loans).HasForeignKey(bc => bc.Filter1Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Filter2).WithMany(p => p.Loans).HasForeignKey(bc => bc.Filter2Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Filter3).WithMany(g => g.Loans).HasForeignKey(bc => bc.Filter3Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Filter4).WithMany(g => g.Loans).HasForeignKey(bc => bc.Filter4Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Group).WithMany(p => p.Loans).HasForeignKey(bc => bc.GroupId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Cycle).WithMany(g => g.Loans).HasForeignKey(bc => bc.CycleId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.RevolvingFund).WithMany(g => g.Loans).HasForeignKey(bc => bc.FundId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.Amortization).WithOne(g => g.Loan).HasForeignKey(bc => bc.LoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.ApprovedAmounts).WithOne(g => g.Loan).HasForeignKey(bc => bc.LoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.ApprovalNotes).WithOne(g => g.Loan).HasForeignKey(bc => bc.LoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.Disbursements).WithOne(g => g.Loan).HasForeignKey(bc => bc.LoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.DefferedLoans).WithOne(g => g.Loan).HasForeignKey(bc => bc.LoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.DeclassifiedLoans).WithOne(g => g.Loan).HasForeignKey(bc => bc.LoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.ExpectedDisbursements).WithOne(g => g.Loan).HasForeignKey(bc => bc.LoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.LoanFreez).WithOne(g => g.Loan).HasForeignKey(bc => bc.LoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.LoanApprovals).WithOne(g => g.Loan).HasForeignKey(bc => bc.LoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.GroupLoanBreakdowns).WithOne(g => g.Loan).HasForeignKey(bc => bc.LoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.Collaterals).WithOne(g => g.Loan).HasForeignKey(bc => bc.LoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.LoanDues).WithOne(g => g.Loan).HasForeignKey(bc => bc.LoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.Guarantors).WithOne(g => g.Loan).HasForeignKey(bc => bc.LoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.LossProvisions).WithOne(g => g.Loan).HasForeignKey(bc => bc.LoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.RepaymentTransactions).WithOne(g => g.Loan).HasForeignKey(bc => bc.LoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.Transfers).WithOne(g => g.Loan).HasForeignKey(bc => bc.LoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.Modifications).WithOne(g => g.Loan).HasForeignKey(bc => bc.LoanId).OnDelete(DeleteBehavior.Cascade);
        }
    }
    
}
