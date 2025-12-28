using MfiManager.Middleware.Data.Entities.Operations.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlSavingProductTaxGroupEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<SavingProductTaxGroup> builder) {
            builder.ToTable("TBL_MFI_SVPRODUCT_TAX_GROUP");
            builder.HasKey(bc => new { bc.SavingProductId, bc.TaxGroupId });
            builder.Property(bc => bc.SavingProductId).HasColumnName("product_id").IsRequired();
            builder.Property(bc => bc.TaxGroupId).HasColumnName("tax_group_id").IsRequired();
            builder.HasOne(bc => bc.SavingProduct).WithMany(p => p.TaxGroups).HasForeignKey(bc => bc.SavingProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.TaxGroup).WithMany(g => g.SavingProducts).HasForeignKey(bc => bc.TaxGroupId).OnDelete(DeleteBehavior.Cascade);
        }

    }
}
