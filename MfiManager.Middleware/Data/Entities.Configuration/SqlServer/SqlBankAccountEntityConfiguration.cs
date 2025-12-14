using MfiManager.Middleware.Data.Entities.Accounts.Cashflows;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlBankAccountEntityConfiguration {

        public static void Configure(EntityTypeBuilder<BankAccount> builder) {
            builder.ToTable("TBL_MFI_BANK_ACC");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.BankBranchId).HasColumnName("branch_id");
            builder.Property(p => p.HolderCode).HasColumnName("holder_code").HasColumnType("NVARCHAR(20)").IsRequired();
            builder.Property(p => p.AccountName).HasColumnName("account_name").HasColumnType("NVARCHAR(250)").IsRequired();
            builder.Property(p => p.AccountNumber).HasColumnName("account_number").HasColumnType("NVARCHAR(40)").IsRequired();
            builder.Property(p => p.IbanNumber).HasColumnName("iban").HasColumnType("NVARCHAR(40)").IsRequired(false);
            builder.Property(p => p.SwiftNumber).HasColumnName("swirdt").HasColumnType("NVARCHAR(40)").IsRequired(false);
            builder.Property(p => p.AccountFor).HasColumnName("holder_type");
            builder.Property(p => p.Operations).HasColumnName("allowed_ops");
            builder.Property(p => p.MultiCurrency).HasColumnName("multi_currency");
            builder.Property(p => p.WithdrawInterval).HasColumnName("withdraw_interval");
            builder.Property(p => p.Duration).HasColumnName("interval_type");
            builder.Property(p => p.LedgerId).HasColumnName("ledger_acc_id").IsRequired(false);
            builder.Property(p => p.HasBook).HasColumnName("has_book");
            builder.Property(p => p.Active).HasColumnName("is_active");
            builder.Property(p => p.ExcludeBranches).HasColumnName("exclude_branch");
            builder.Property(p => p.CreditLimit).HasColumnName("credit_limit");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.BankBranch).WithMany(d => d.Accounts).HasForeignKey(u => u.BankBranchId);
            builder.HasOne(p => p.LedgerAccount).WithMany(a => a.BankAccounts).HasForeignKey(u => u.LedgerId);
            builder.HasMany(p => p.Books).WithOne(q => q.BankAccount).HasForeignKey(q => q.BankAccountId);
            builder.HasMany(p => p.Currencies).WithOne(bc => bc.BankAccount).HasForeignKey(bc => bc.BankAccountId);
            builder.HasMany(p => p.Suppliers).WithOne(b => b.BankAccount).HasForeignKey(p => p.BankAccountId);
            builder.HasMany(p => p.BankTransaction).WithOne(b => b.BankAccount).HasForeignKey(p => p.BankAccountId);
            builder.HasMany(p => p.SalesOrderDefaults).WithOne(b => b.BankAccount).HasForeignKey(p => p.BankAccountId);
            builder.HasMany(p => p.PurchaseOrderDefaults).WithOne(b => b.BankAccount).HasForeignKey(p => p.BankAccountId);
            builder.HasMany(p => p.DefaultVendorPayments).WithOne(b => b.BankAccount).HasForeignKey(p => p.BankAccountId);
        }
    }

}
