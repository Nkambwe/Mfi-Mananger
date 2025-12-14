using MfiManager.Middleware.Data.Entities.Operations.Vendors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlSupplierReferenceEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<SupplierReference> builder) {
            builder.ToTable("TBL_MFI_SUPPLIER_REFERENCE");
            builder.HasKey(bc => new { bc.ReferenceValueId, bc.SupplierId });
            builder.Property(bc => bc.ReferenceValueId).HasColumnName("ref_id").IsRequired();
            builder.Property(bc => bc.SupplierId).HasColumnName("supplier_id").IsRequired();
            builder.HasOne(bc => bc.ReferenceValue).WithMany(p => p.SupplierReferences).HasForeignKey(bc => bc.SupplierId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Supplier).WithMany(g => g.SupplierReferences).HasForeignKey(bc => bc.ReferenceValueId).OnDelete(DeleteBehavior.Cascade);
        }

    }

}
