using MfiManager.Middleware.Data.Entities.Accounts.Currecies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlDenominationEntityConfiguration {

        public static void Configure(EntityTypeBuilder<Denomination> builder) {
            builder.ToTable("TBL_MFI_CURRENCY_DENOM");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Name).HasColumnName("denom_name").HasColumnType("NVARCHAR(160)").IsRequired();
            builder.Property(p => p.Symbol).HasColumnName("currency_symbol").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.Value).HasColumnName("currency_value");
            builder.Property(p => p.CurrencyId).HasColumnName("currency_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(u => u.Currency).WithMany(q => q.Denominations).HasForeignKey(q => q.CurrencyId);
        }
    }

}
