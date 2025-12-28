using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlLoanCycleEntityConfiguration {

        public static void Configure(EntityTypeBuilder<LoanCycle> builder) {
            builder.ToTable("TBL_MFI_LOAN_CYCLE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.CycleNumber).HasColumnName("cycle_number");
            builder.Property(p => p.MinimumAmount).HasColumnName("min_amount").HasPrecision(9,2);
            builder.Property(p => p.MaximumAmount).HasColumnName("max_amount").HasPrecision(9,2);
            builder.Property(p => p.MinimumInterestRate).HasColumnName("min_int_rate").HasPrecision(9,2);
            builder.Property(p => p.MaximumInterestRate).HasColumnName("max_int_rate").HasPrecision(9,2);
            builder.Property(p => p.CommissionAsPercentage).HasColumnName("comm_as_per");
            builder.Property(p => p.MinimumCommissionAtApplication).HasColumnName("min_comm_appln").HasPrecision(9,2);
            builder.Property(p => p.MaximumCommissionAtApplication).HasColumnName("max_comm_appln").HasPrecision(9,2);
            builder.Property(p => p.MinimumCommissionAtDisbursement).HasColumnName("min_comm_disb").HasPrecision(9,2);
            builder.Property(p => p.MaximumCommissionAtDisbursement).HasColumnName("max_comm_disb").HasPrecision(9,2);
            builder.Property(p => p.IndividualAccountId).HasColumnName("individual_acc_id").IsRequired(false);
            builder.Property(p => p.BusinessAccountId).HasColumnName("business_acc_id").IsRequired(false);
            builder.Property(p => p.GroupAccountId).HasColumnName("group_acc_id").IsRequired(false);
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.IndividualAccount).WithMany(e => e.LoanCycles).HasForeignKey(e => e.IndividualAccountId);
            builder.HasOne(p => p.BusinessAccount).WithMany(e => e.LoanCycles).HasForeignKey(e => e.BusinessAccountId);
            builder.HasOne(p => p.GroupAccount).WithMany(e => e.LoanCycles).HasForeignKey(e => e.GroupAccountId);
        }
    }
}
