using MfiManager.Middleware.Data.Entities.Operations.Trade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlPaymentTermEntityConfiguration {

        public static void Configure(EntityTypeBuilder<PaymentTerm> builder) {
            builder.ToTable("TBL_MFI_PAYMENT_TERMS");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Terms).HasColumnName("terms").HasColumnType("NVARCHAR(180)").IsRequired();
            builder.Property(p => p.Description).HasColumnName("terms_descr").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(p => p.PaymentDefaults).WithOne(d => d.PaymentTerms).HasForeignKey(d => d.PaymentTermsId);
        }
    }

}
