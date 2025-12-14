using MfiManager.Middleware.Data.Entities.Operations.Trade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlDeliveryTermsEntityConfiguration {

        public static void Configure(EntityTypeBuilder<DeliveryTerms> builder) {
            builder.ToTable("TBL_MFI_DELIVERY_TERMS");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("code").HasColumnType("NVARCHAR(10)");
            builder.Property(p => p.Description).HasColumnName("terms_description").HasColumnType("NVARCHAR(MAX)");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(p => p.Traders).WithOne(t => t.DeliverTerms).HasForeignKey(t => t.DeliverTermsId);
            builder.HasMany(p => p.Suppliers).WithOne(s => s.DeliverTerms).HasForeignKey(s => s.DeliverTermsId);
        }
    }
}
