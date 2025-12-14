using MfiManager.Middleware.Data.Entities.Operations.Trade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlTraderReferenceEntityConfiguration {

        public static void Configure(EntityTypeBuilder<TraderReference> builder) {
            builder.ToTable("TBL_MFI_VENDOR_REFERENCE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.VendorId).HasColumnName("vendor_id");
            builder.Property(p => p.ReferenceValueId).HasColumnName("ref_value_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.ReferenceValue).WithMany(o => o.VendorReferences).HasForeignKey(mp => mp.ReferenceValueId);
            builder.HasOne(m => m.Vendor).WithMany(o => o.RefereceValues).HasForeignKey(mp => mp.ReferenceValueId);
        }
    }
}
