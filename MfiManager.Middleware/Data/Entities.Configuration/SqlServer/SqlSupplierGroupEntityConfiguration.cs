using MfiManager.Middleware.Data.Entities.Operations.Vendors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlSupplierGroupEntityConfiguration {

        public static void Configure(EntityTypeBuilder<SupplierGroup> builder) {
            builder.ToTable("TBL_MFI_SUPPLIER_CATEGORY");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("code").HasColumnType("NVARCHAR(10)");
            builder.Property(p => p.Group).HasColumnName("category_name").HasColumnType("NVARCHAR(200)");
            builder.Property(p => p.Notes).HasColumnName("group_notes").HasColumnType("NVARCHAR(MAX)");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(p => p.Suppliers).WithOne(t => t.SupplierGroup).HasForeignKey(t => t.SupplierGroupId);
            builder.HasMany(p => p.OrderDefaults).WithOne(t => t.SupplierGroup).HasForeignKey(t => t.SupplierGroupId);
            builder.HasMany(p => p.SuppliedBranches).WithOne(t => t.SupplierGroup).HasForeignKey(t => t.SupplierGroupId);
        }
    }

}
