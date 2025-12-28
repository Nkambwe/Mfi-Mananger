using MfiManager.Middleware.Data.Entities.Operations.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlTimedepositProductTaxGroupEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<TimedepositProductTaxGroup> builder) {
            builder.ToTable("TBL_MFI_TDPRODUCT_TAX_GROUP");
            builder.HasKey(bc => new { bc.TimedepositProductId, bc.TaxGroupId });
            builder.Property(bc => bc.TimedepositProductId).HasColumnName("product_id").IsRequired();
            builder.Property(bc => bc.TaxGroupId).HasColumnName("tax_group_id").IsRequired();
            builder.HasOne(bc => bc.TimedepositProduct).WithMany(p => p.TaxGroups).HasForeignKey(bc => bc.TimedepositProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.TaxGroup).WithMany(g => g.TimedepositProducts).HasForeignKey(bc => bc.TaxGroupId).OnDelete(DeleteBehavior.Cascade);
        }

    }
}
