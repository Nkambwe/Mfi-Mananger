using MfiManager.Middleware.Data.Entities.Accounts.Taxes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlSupplierTaxEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<SupplierTax> builder) {
            builder.ToTable("TBL_MFI_SUPPLIER_TAX");
            builder.HasKey(bc => new { bc.SupplierId, bc.TaxId });
            builder.Property(bc => bc.TaxId).HasColumnName("tax_id").IsRequired();
            builder.Property(bc => bc.SupplierId).HasColumnName("supplier_id").IsRequired();
            builder.HasOne(bc => bc.Tax).WithMany(p => p.Suppliers).HasForeignKey(bc => bc.SupplierId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Supplier).WithMany(g => g.SalesTaxes).HasForeignKey(bc => bc.TaxId).OnDelete(DeleteBehavior.Cascade);
        }

    }

}
