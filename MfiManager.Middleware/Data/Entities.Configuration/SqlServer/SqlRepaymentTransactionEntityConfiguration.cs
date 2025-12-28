using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlRepaymentTransactionEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<RepaymentLedger> builder) {
            builder.ToTable("TBL_MFI_LOAN_REPAYMENT_TRANSACTION");
            builder.HasKey(p => p.Id );
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.PaymentDate).HasColumnName("payment_date").IsRequired();
            builder.Property(p => p.Payment).HasColumnName("payment_mode").IsRequired();
            builder.Property(p => p.Principal).HasColumnName("principal").HasPrecision(9,2);
            builder.Property(p => p.Interest).HasColumnName("interest").HasPrecision(9,2);
            builder.Property(p => p.Commission).HasColumnName("commission").HasPrecision(9,2);
            builder.Property(p => p.Penalty).HasColumnName("penalty").HasPrecision(9,2);
            builder.Property(p => p.OverPayment).HasColumnName("over_payment").HasPrecision(9,2);
            builder.Property(p => p.Vat).HasColumnName("vat_amount").HasPrecision(9,2);
            builder.Property(p => p.ProcessedBy).HasColumnName("processed_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.IndividualLoanId).HasColumnName("individual_lnr_id").IsRequired(false);
            builder.HasOne(bc => bc.IndividualLoan).WithMany(p => p.RepaymentTransactions).HasForeignKey(bc => bc.IndividualLoanId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(p => p.BusinessLoanId).HasColumnName("business_lnr_id").IsRequired(false);
            builder.HasOne(bc => bc.GroupLoan).WithMany(p => p.RepaymentTransactions).HasForeignKey(bc => bc.GroupLoanId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(p => p.GroupLoanId).HasColumnName("group_lnr_id").IsRequired(false);
            builder.HasOne(bc => bc.BusinessLoan).WithMany(p => p.RepaymentTransactions).HasForeignKey(bc => bc.BusinessLoanId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(p => p.SavingAccountId).HasColumnName("saving_acc_id").IsRequired(false);
            builder.HasOne(bc => bc.SavingAccount).WithMany(p => p.RepaymentTransactions).HasForeignKey(bc => bc.SavingAccountId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.MembersRepayments).WithOne(g => g.RepaymentTransaction).HasForeignKey(bc => bc.RepaymentId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
