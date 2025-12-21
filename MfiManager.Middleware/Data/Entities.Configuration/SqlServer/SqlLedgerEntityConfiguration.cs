using MfiManager.Middleware.Data.Entities.Accounts.Ledgers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {

    public class SqlLedgerEntityConfiguration {

        public static void Configure(EntityTypeBuilder<Ledger> builder) {
            builder.ToTable("TBL_MFI_GENERAL_LEDGER");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.LedgerAccountId).HasColumnName("ledger_account_id");
            builder.Property(p => p.TransactionCode).HasColumnName("trans_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.PostedOn).HasColumnName("posted_on").IsRequired();
            builder.Property(p => p.Particulars).HasColumnName("particulars").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.Folio).HasColumnName("folio").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.LedgerNumber).HasColumnName("ledger_number").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.PostingSeries).HasColumnName("posting_series").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.Voucher).HasColumnName("voucher").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.Debit).HasColumnName("debit").HasPrecision(9,2);
            builder.Property(p => p.Credit).HasColumnName("credit").HasPrecision(9,2);
            builder.Property(p => p.Currency).HasColumnName("currency").HasColumnType("NVARCHAR(3)").IsRequired();
            builder.Property(p => p.ExchangeAmount).HasColumnName("exchange_amount").HasPrecision(9,2);
            builder.Property(p => p.GeneralPosting).HasColumnName("general_posting").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.BusinessPosting).HasColumnName("business_posting").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.ChargePosting).HasColumnName("charge_posting").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.Reference1).HasColumnName("reference_1").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.Reference2).HasColumnName("reference_2").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.Reference3).HasColumnName("reference_3").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.Reference4).HasColumnName("reference_4").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.Reference5).HasColumnName("reference_5").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.Reference6).HasColumnName("reference_6").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.TaxCode).HasColumnName("tax_code").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.TaxCharge1).HasColumnName("tax_charge_1").HasPrecision(9,2);
            builder.Property(p => p.TaxCharge2).HasColumnName("tax_charge_2").HasPrecision(9,2);
            builder.Property(p => p.Closed).HasColumnName("is_month_closed").IsRequired();
            builder.Property(p => p.ClosedOn).HasColumnName("month_closed_on").IsRequired(false);
            builder.Property(p => p.MonthlyClosureId).HasColumnName("monthly_closure_id").IsRequired(false);
            builder.Property(p => p.LedgerAccountId).HasColumnName("ledger_account_id");
            builder.Property(p => p.Cashier).HasColumnName("cashier").HasColumnType("NVARCHAR(10)");
            builder.Property(p => p.Comment).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.MonthlyClosure).WithMany(o => o.GeneralLedgerTransactions).HasForeignKey(mp => mp.MonthlyClosureId);
            builder.HasOne(m => m.LedgerAccount).WithMany(o => o.GeneralLedgerTransactions).HasForeignKey(mp => mp.LedgerAccountId);
            builder.HasMany(m => m.CardTransactions).WithOne(o => o.GeneralLedgerTransaction).HasForeignKey(mp => mp.GeneralLedgerTransactionId);
            builder.HasMany(m => m.VoucherTransactions).WithOne(o => o.GeneralLedgerTransaction).HasForeignKey(mp => mp.GeneralLedgerTransactionId);
            builder.HasMany(m => m.RegistrationFeeTransactions).WithOne(o => o.GeneralLedgerTransaction).HasForeignKey(mp => mp.GeneralLedgerTransactionId);
            builder.HasMany(m => m.InsuranceFeeTransactions).WithOne(o => o.GeneralLedgerTransaction).HasForeignKey(mp => mp.GeneralLedgerTransactionId);
            builder.HasMany(m => m.ShareFeeTransactions).WithOne(o => o.GeneralLedgerTransaction).HasForeignKey(mp => mp.GeneralLedgerTransactionId);
            builder.HasMany(m => m.SavingnFeeTransactions).WithOne(o => o.GeneralLedgerTransaction).HasForeignKey(mp => mp.GeneralLedgerTransactionId);
            builder.HasMany(m => m.TimedepositFeeTransactions).WithOne(o => o.GeneralLedgerTransaction).HasForeignKey(mp => mp.GeneralLedgerTransactionId);
        }
    }

}
