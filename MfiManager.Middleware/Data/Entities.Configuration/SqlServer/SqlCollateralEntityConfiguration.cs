using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlCollateralEntityConfiguration {

        public static void Configure(EntityTypeBuilder<Collateral> builder) {
            builder.ToTable("TBL_MFI_COLLATERAL");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.OverdraftNumber).HasColumnName("overdraft").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.CollateralType).HasColumnName("collateral_type");
            builder.Property(p => p.Description).HasColumnName("description").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.CollateralValue).HasColumnName("collateral_value").HasPrecision(9,2);
            builder.Property(p => p.GuarantorId).HasColumnName("guarantor_id");
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Guarantor).WithMany(e => e.Collateral).HasForeignKey(e => e.GuarantorId);
            builder.HasMany(p => p.Images).WithOne(e => e.Collateral).HasForeignKey(e => e.CollateralId);
        }
    }

    public class SqlLoanRefinanceEntityConfiguration {

        public static void Configure(EntityTypeBuilder<LoanRefinance> builder) {
            builder.ToTable("TBL_MFI_LOAN_REFINANCE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.TransactionCode).HasColumnName("trans_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.CurrentLoanNumber).HasColumnName("current_lnr_number").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.RefinancedOn).HasColumnName("refib_date");
            builder.Property(p => p.Amount).HasColumnName("loan_amount").HasPrecision(9,2);
            builder.Property(p => p.Fees).HasColumnName("loan_fees").HasPrecision(9,2);
            builder.Property(p => p.CapitalizeInterest).HasColumnName("cap_inter");
            builder.Property(p => p.CapitalizeCommission).HasColumnName("cap_comm");
            builder.Property(p => p.CapitalizeFees).HasColumnName("cap_feed");
            builder.Property(p => p.CapitalizePenalty).HasColumnName("cap_pen");
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.ReasonId).HasColumnName("reason_id");
            builder.Property(p => p.RefinancedIndividualLoanId).HasColumnName("ind_ref_id").IsRequired(false);
            builder.Property(p => p.RefinancedGroupLoanId).HasColumnName("grp_ref_id").IsRequired(false);
            builder.Property(p => p.RefinancedBusinessLoanId).HasColumnName("biz_ref_id").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Reason).WithMany(e => e.Loans).HasForeignKey(e => e.ReasonId);
            builder.HasOne(p => p.RefinancedIndividualLoan).WithMany(e => e.RefinancedLoans).HasForeignKey(e => e.RefinancedIndividualLoanId);
            builder.HasOne(p => p.RefinancedGroupLoan).WithMany(e => e.RefinancedLoans).HasForeignKey(e => e.RefinancedGroupLoanId);
            builder.HasOne(p => p.RefinancedBusinessLoan).WithMany(e => e.RefinancedLoans).HasForeignKey(e => e.RefinancedBusinessLoanId);

        }
    }
}
