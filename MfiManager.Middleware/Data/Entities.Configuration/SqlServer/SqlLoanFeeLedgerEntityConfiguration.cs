using MfiManager.Middleware.Data.Entities.Accounts.Fees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlLoanFeeLedgerEntityConfiguration {

        public static void Configure(EntityTypeBuilder<LoanFeeLedger> builder) {
            builder.ToTable("TBL_MFI_LOAN_FEE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.GeneralLedgerTransactionId).HasColumnName("trans_id");
            builder.Property(p => p.TransactionCode).HasColumnName("trans_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.Particulars).HasColumnName("particulars").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.PostedOn).HasColumnName("trans_date").IsRequired();
            builder.Property(p => p.Payment).HasColumnName("pay_mode").IsRequired();
            builder.Property(p => p.Cheque).HasColumnName("cheque_number").IsRequired(false);
            builder.Property(p => p.Amount).HasColumnName("amount").HasPrecision(9,2);
            builder.Property(p => p.Cashier).HasColumnName("cashier").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.LoanId).HasColumnName("loan_id");
            builder.Property(p => p.FeeId).HasColumnName("fee_id");
            builder.Property(p => p.LoanFeePaymentLevelId).HasColumnName("fee_payment_level_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Fee).WithMany(o => o.LoanFeeTransactions).HasForeignKey(mp => mp.FeeId);
            builder.HasOne(m => m.GeneralLedgerTransaction).WithMany(o => o.LoanFeeTransactions).HasForeignKey(mp => mp.GeneralLedgerTransactionId);
        }
    }
}
