using MfiManager.Middleware.Data.Entities.Operations.Vendors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlSuppliedBranchEntityConfiguration {

        public static void Configure(EntityTypeBuilder<SuppliedBranch> builder) {
            builder.ToTable("TBL_MFI_SUPPLIED_BRANCH");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Branch).HasColumnName("branch_name").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(p => p.OnHold).HasColumnName("on_hold");
            builder.Property(p => p.SupplierId).HasColumnName("supplier_id");
            builder.Property(p => p.SupplierGroupId).HasColumnName("group_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(u => u.SupplierInfo).WithMany(c => c.SuppliedBranches).HasForeignKey(bc => bc.SupplierId);
            builder.HasOne(u => u.SupplierGroup).WithMany(c => c.SuppliedBranches).HasForeignKey(bc => bc.SupplierGroupId);
        }
    }

}
