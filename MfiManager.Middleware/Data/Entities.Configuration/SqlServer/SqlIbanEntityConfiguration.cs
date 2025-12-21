using MfiManager.Middleware.Data.Entities.Accounts.Cashflows;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlIbanEntityConfiguration {
        public static void Configure(EntityTypeBuilder<Iban> builder) {
             builder.ToTable("IBAN");
             builder.HasKey(p => p.Id);
             builder.Property(p => p.Id).HasColumnName("id");
             builder.Property(p => p.Code).HasColumnName("iban_code").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.Naration).HasColumnName("naration").HasColumnType("NVARCHAR(250)").IsRequired();
             builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
             builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
             builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
             builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
             builder.HasMany(m => m.Banks).WithOne(o => o.Iban).HasForeignKey(mp => mp.IbanId);
        }
    }
}
