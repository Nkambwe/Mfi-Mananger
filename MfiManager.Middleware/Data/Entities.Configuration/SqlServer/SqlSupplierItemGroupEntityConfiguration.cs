using MfiManager.Middleware.Data.Entities.Operations.Vendors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlSupplierItemGroupEntityConfiguration {

        public static void Configure(EntityTypeBuilder<SupplierItemGroup> builder) {
            builder.ToTable("TBL_MFI_SUPPLIER_ITEM_GROUP");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("group_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ItemGroup).HasColumnName("item_group").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(p => p.Notes).HasColumnName("group_notes").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(m => m.PurchaseOrderDefaults).WithOne(o => o.ItemGroup).HasForeignKey(mp => mp.ItemGroupId);
        }
    }
}
