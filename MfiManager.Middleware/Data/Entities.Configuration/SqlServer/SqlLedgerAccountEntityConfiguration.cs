using MfiManager.Middleware.Data.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {

    public class SqlLedgerAccountEntityConfiguration {
        public static void Configure(EntityTypeBuilder<LedgerAccount> builder) {
             builder.ToTable("TBL_MFI_LEDGER_ACC");
             builder.HasKey(p => p.Id);
             builder.Property(p => p.Id).HasColumnName("id");
             builder.Property(p => p.LedgerNumber).HasColumnName("ledger_number").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.LedgerName).HasColumnName("ledger_name").HasColumnType("NVARCHAR(MAX)").IsRequired();
             builder.Property(p => p.AccountClassification).HasColumnName("acc_classification");
             builder.Property(p => p.AccountCategory).HasColumnName("acc_category");
             builder.Property(p => p.AccountNature).HasColumnName("acc_nature");
             builder.Property(p => p.GroupIndex).HasColumnName("group_index");
             builder.Property(p => p.LedgerIndex).HasColumnName("ledger_index");
             builder.Property(p => p.NormalBalance).HasColumnName("normal_bal");
             builder.Property(p => p.PostingType).HasColumnName("posting_type");
             builder.Property(p => p.AllowManualPosting).HasColumnName("allow_manual_posting");
             builder.Property(p => p.ShowParticulars).HasColumnName("show_particulars");
             builder.Property(p => p.Suspended).HasColumnName("is_suspended");
             builder.Property(p => p.Balance).HasColumnName("balance").HasPrecision(9,2);
             builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired();
             builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
             builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
             builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
             builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
             builder.Property(p => p.LedgerAccountHeaderId).HasColumnName("acc_header_id");
             builder.Property(p => p.FolioId).HasColumnName("folio_id").IsRequired(false);
             builder.Property(p => p.CurrencyId).HasColumnName("currency_id").IsRequired(false);
             builder.Property(p => p.ExchangeRateId).HasColumnName("exchange_rate_id").IsRequired(false);
             builder.Property(p => p.AccountsChartId).HasColumnName("acc_chart_id");
             builder.HasOne(m => m.Folio).WithMany(o => o.LedgerAccounts).HasForeignKey(mp => mp.FolioId);
             builder.HasOne(m => m.AccountsChart).WithMany(o => o.LedgerAccounts).HasForeignKey(mp => mp.AccountsChartId);
             builder.HasOne(m => m.Currency).WithMany(o => o.LedgerAccounts).HasForeignKey(mp => mp.CurrencyId);
             builder.HasOne(m => m.LedgerAccountHeader).WithMany(o => o.LedgerAccounts).HasForeignKey(mp => mp.LedgerAccountHeaderId);
             builder.HasMany(m => m.References).WithOne(o => o.LedgerAccount).HasForeignKey(mp => mp.LedgerAccountId);
             builder.HasMany(m => m.CashAccounts).WithOne(o => o.LedgerAccount).HasForeignKey(mp => mp.LedgerAccountId);
             builder.HasMany(m => m.BankAccounts).WithOne(o => o.LedgerAccount).HasForeignKey(mp => mp.LedgerId);
             builder.HasMany(m => m.GeneralLedgerTransactions).WithOne(o => o.LedgerAccount).HasForeignKey(mp => mp.LedgerAccountId);
        }
    }

}
