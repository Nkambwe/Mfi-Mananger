using MfiManager.Middleware.Data.Entities.Accounts.Fees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlChargeableFeeEntityConfiguration {

        public static void Configure(EntityTypeBuilder<ChargeableFee> builder) {
            builder.ToTable("TBL_MFI_FEE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Name).HasColumnName("fee_name").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(p => p.ApplyToRegistration).HasColumnName("apply_to_reg");
            builder.Property(p => p.ApplyToSavings).HasColumnName("apply_to_saving");
            builder.Property(p => p.ApplyToTimeDeposits).HasColumnName("apply_to_timedep");
            builder.Property(p => p.ApplyToShares).HasColumnName("apply_to_shares");
            builder.Property(p => p.ApplyToInsurance).HasColumnName("apply_to_insure");
            builder.Property(p => p.ApplyToLoans).HasColumnName("apply_to_loan");
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(m => m.RegistrationFeeTransactions).WithOne(o => o.Fee).HasForeignKey(mp => mp.FeeId);
            builder.HasMany(m => m.SavingFeeTransactions).WithOne(o => o.Fee).HasForeignKey(mp => mp.FeeId);
            builder.HasMany(m => m.TimedepositFeeTransactions).WithOne(o => o.Fee).HasForeignKey(mp => mp.FeeId);
            builder.HasMany(m => m.ShareFeeTransactions).WithOne(o => o.Fee).HasForeignKey(mp => mp.FeeId);
            builder.HasMany(m => m.InsuranceFeeTransactions).WithOne(o => o.Fee).HasForeignKey(mp => mp.FeeId);
            builder.HasMany(m => m.LoanFeeTransactions).WithOne(o => o.Fee).HasForeignKey(mp => mp.FeeId);
        }
    }
}
