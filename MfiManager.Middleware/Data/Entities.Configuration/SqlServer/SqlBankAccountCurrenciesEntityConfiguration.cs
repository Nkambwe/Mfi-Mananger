using MfiManager.Middleware.Data.Entities.Accounts.Currecies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlBankAccountCurrenciesEntityConfiguration {

        public static void Configure(EntityTypeBuilder<BankAccountCurrencies> builder) {
            builder.ToTable("TBL_MFI_BANK_ACC_CURRENCY");
            builder.HasKey(bc => new { bc.BankAccountId, bc.CurrencyId });
            builder.Property(bc => bc.BankAccountId).HasColumnName("account_id").IsRequired();
            builder.Property(bc => bc.CurrencyId).HasColumnName("currency_id").IsRequired();
            builder.HasOne(bc => bc.BankAccount).WithMany(p => p.Currencies).HasForeignKey(bc => bc.CurrencyId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Currency).WithMany(g => g.BankAccounts).HasForeignKey(bc => bc.BankAccountId).OnDelete(DeleteBehavior.Cascade);
        }
    }

}
