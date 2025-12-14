using MfiManager.Middleware.Data.Entities.Operations.Insurance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlPremiumPaymentLedgerEntityConfiguration {
        public static void Configure(EntityTypeBuilder<PremiumPaymentLedger> builder) {
            builder.ToTable("TBL_MFI_PREMIUM_PAYMENT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.TransactionCode).HasColumnName("trans_code").HasColumnType("NVARCHAR(10)");
            builder.Property(p => p.Particulars).HasColumnName("particulars").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.PaidOn).HasColumnName("paid_on");
            builder.Property(p => p.Payment).HasColumnName("payment_mode");
            builder.Property(p => p.PremiumAmount).HasColumnName("premium_amount").HasPrecision(9,2);
            builder.Property(p => p.PremiumFees).HasColumnName("premium_fees").HasPrecision(9,2);
            builder.Property(p => p.Discount).HasColumnName("discount").HasPrecision(9,2);
            builder.Property(p => p.Cashier).HasColumnName("cashier").HasColumnType("NVARCHAR(10)");
            builder.Property(p => p.PolicyId).HasColumnName("policy_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Policy).WithMany(o => o.PremiumPayments).HasForeignKey(mp => mp.PolicyId);
        }
     }
}
