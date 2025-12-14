using MfiManager.Middleware.Data.Entities.Operations.Insurance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {

    public class SqlInsuranceProductProviderEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<InsuranceProductProvider> builder) {
            builder.ToTable("TBL_MFI_INSURANCE_PRODUCT_PROVIDER");
            builder.HasKey(bc => new { bc.ProductId, bc.ProviderId });
            builder.Property(bc => bc.ProductId).HasColumnName("product_id").IsRequired();
            builder.Property(bc => bc.ProviderId).HasColumnName("provider_id").IsRequired();
            builder.HasOne(bc => bc.Product).WithMany(p => p.Providers).HasForeignKey(bc => bc.ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Provider).WithMany(g => g.Products).HasForeignKey(bc => bc.ProviderId).OnDelete(DeleteBehavior.Cascade);
        }

    }

}
