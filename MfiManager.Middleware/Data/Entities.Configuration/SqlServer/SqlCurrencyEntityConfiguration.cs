using MfiManager.Middleware.Data.Entities.Accounts.Currecies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlCurrencyEntityConfiguration {

        public static void Configure(EntityTypeBuilder<Currency> builder) {
            builder.ToTable("TBL_MFI_CURRENCY");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("currency_code").HasColumnType("NVARCHAR(3)").IsRequired();
            builder.Property(p => p.Name).HasColumnName("currency_name").HasColumnType("NVARCHAR(160)").IsRequired();
            builder.Property(p => p.SmallUnit).HasColumnName("small_units").HasColumnType("NVARCHAR(160)").IsRequired();
            builder.Property(p => p.Symbol).HasColumnName("currency_symbol").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.Round).HasColumnName("round_precision");
            builder.Property(p => p.BaseCurrency).HasColumnName("is_base_currency");
            builder.Property(p => p.Country).HasColumnName("currency_of");
            builder.Property(p => p.System).HasColumnName("system_currency");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(p => p.Denominations).WithOne(q => q.Currency).HasForeignKey(q => q.CurrencyId);
            builder.HasMany(p => p.BankAccounts).WithOne(bc => bc.Currency).HasForeignKey(bc => bc.CurrencyId);
            builder.HasMany(p => p.ExchangeRates).WithOne(x => x.Currency).HasForeignKey(x => x.CurrencyId);
            builder.HasMany(p => p.BankAccounts).WithOne(bc => bc.Currency).HasForeignKey(bc => bc.CurrencyId);
        }
    }

}
