using MfiManager.Middleware.Data.Entities.Accounts.Currecies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlExchangeRateEntityConfiguration {

        public static void Configure(EntityTypeBuilder<ExchangeRate> builder) {
            builder.ToTable("TBL_MFI_FXRATES");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Against).HasColumnName("alt_currency").HasColumnType("NVARCHAR(3)").IsRequired();
            builder.Property(p => p.Buy).HasColumnName("buy_rate").IsRequired();
            builder.Property(p => p.Sale).HasColumnName("sale_rate").IsRequired();
            builder.Property(p => p.Average).HasColumnName("avg_rate").IsRequired();
            builder.Property(p => p.IsRunning).HasColumnName("is_running");
            builder.Property(p => p.CurrencyId).HasColumnName("currency_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Currency).WithMany(c => c.ExchangeRates).HasForeignKey(x => x.CurrencyId);
        }
    }

}
