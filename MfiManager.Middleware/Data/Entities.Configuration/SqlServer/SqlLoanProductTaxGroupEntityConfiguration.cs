using MfiManager.Middleware.Data.Entities.Operations.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlLoanProductTaxGroupEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<LoanProductTaxGroup> builder) {
            builder.ToTable("TBL_MFI_LNPRODUCT_TAX_GROUP");
            builder.HasKey(bc => new { bc.ProductId, bc.TaxGroupId });
            builder.Property(bc => bc.ProductId).HasColumnName("product_id").IsRequired();
            builder.Property(bc => bc.TaxGroupId).HasColumnName("tax_group_id").IsRequired();
            builder.HasOne(bc => bc.Product).WithMany(p => p.TaxGroups).HasForeignKey(bc => bc.ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.TaxGroup).WithMany(g => g.LoanProducts).HasForeignKey(bc => bc.TaxGroupId).OnDelete(DeleteBehavior.Cascade);
        }

    }
}
