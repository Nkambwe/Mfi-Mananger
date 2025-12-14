using MfiManager.Middleware.Data.Entities.Operations.Trade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlTraderTaxEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<TraderTax> builder) {
            builder.ToTable("TBL_MFI_VENDOR_TAX");
            builder.HasKey(bc => new { bc.TaxId, bc.VendorId });
            builder.Property(bc => bc.TaxId).HasColumnName("tax_id").IsRequired();
            builder.Property(bc => bc.VendorId).HasColumnName("vendor_id").IsRequired();
            builder.HasOne(bc => bc.Tax).WithMany(p => p.Vendors).HasForeignKey(bc => bc.VendorId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Vendor).WithMany(g => g.SalesTaxes).HasForeignKey(bc => bc.TaxId).OnDelete(DeleteBehavior.Cascade);
        }

    }

}
