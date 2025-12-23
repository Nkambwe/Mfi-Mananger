using MfiManager.Middleware.Data.Entities.Operations.Insurance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlClaimPaymentLedgerEntityConfiguration {
        public static void Configure(EntityTypeBuilder<ClaimPaymentLedger> builder) {
            builder.ToTable("TBL_MFI_CLAIM_PAYMENTS_LEDGER");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.TransactionCode).HasColumnName("trans_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.PaidOn).HasColumnName("paid_on");
            builder.Property(p => p.Particulars).HasColumnName("particulars").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.Payment).HasColumnName("payment_mode");
            builder.Property(p => p.Paid).HasColumnName("amount_paid").HasPrecision(9,2);
            builder.Property(p => p.Outstanding).HasColumnName("outstanding_bal").HasPrecision(9,2);
            builder.Property(p => p.TotalPaid).HasColumnName("total_amount").HasPrecision(9,2);
            builder.Property(p => p.ClaimAmount).HasColumnName("claim_amount").HasPrecision(9,2);
            builder.Property(p => p.Cashier).HasColumnName("cashier").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ClaimId).HasColumnName("claim_id");
            builder.Property(p => p.TransactionId).HasColumnName("transaction_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Claim).WithMany(o => o.Transactions).HasForeignKey(mp => mp.ClaimId);
            builder.HasOne(m => m.GeneralLedgerTransaction).WithMany(o => o.ClaimPaymentTransactions).HasForeignKey(mp => mp.TransactionId);
        }
    }
}
