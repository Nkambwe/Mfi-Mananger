using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlLoanFeePaymentLevelEntityConfiguration {

        public static void Configure(EntityTypeBuilder<LoanFeePaymentLevel> builder) {
            builder.ToTable("TBL_MFI_LOANFEE_PAYMENT_LEVEL");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ProductId).HasColumnName("product_id");
            builder.Property(p => p.Required).HasColumnName("is_required");
            builder.Property(p => p.PercentageRate).HasColumnName("percentage_rate").HasPrecision(9,2);
            builder.Property(p => p.FlatAmount).HasColumnName("flat_amount").HasPrecision(9,2);
            builder.Property(p => p.PayBeforeApplication).HasColumnName("pay_before_application");
            builder.Property(p => p.BeforeApplicationFeeLedger).HasColumnName("before_application_fee_ledger").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.PayBeforeApproval).HasColumnName("pay_before_approval");
            builder.Property(p => p.BeforeApprovalFeeLedger).HasColumnName("before_approval_fee_ledger").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.PayAfterApproval).HasColumnName("pay_after_approval");
            builder.Property(p => p.AfterApprovalFeeLedger).HasColumnName("after_approval_fee_ledger").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.PayAtDisbursement).HasColumnName("pay_at_disbursement");
            builder.Property(p => p.DisbursementFeeLedger).HasColumnName("disbursement_fee_ledger").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.IsGeneralFee).HasColumnName("is_general_fee");
            builder.Property(p => p.GeneralFeeLedger).HasColumnName("general_fee_ledger").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Product).WithMany(o => o.FeesPaymentLevels).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.LoanFeeTransactions).WithOne(o => o.LoanFeePaymentLevel).HasForeignKey(mp => mp.LoanFeePaymentLevelId);
        }
    }
}
