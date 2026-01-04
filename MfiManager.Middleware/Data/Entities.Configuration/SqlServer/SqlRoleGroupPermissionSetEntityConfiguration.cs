using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {

    public class SqlRoleGroupPermissionSetEntityConfiguration {

        public static void Configure(EntityTypeBuilder<RoleGroupPermissionSet> builder) {
            builder.ToTable("TBL_MFI_ROLEGROUP_PERMISSIONSET");
            builder.HasKey(bc => new { bc.PermissionSetId, bc.RoleGroupId });
            builder.Property(bc => bc.PermissionSetId).HasColumnName("permission_set_id").IsRequired();
            builder.Property(bc => bc.RoleGroupId).HasColumnName("role_group_id").IsRequired();
            builder.HasOne(bc => bc.PermissionSet).WithMany(p => p.RoleGroups).HasForeignKey(bc => bc.RoleGroupId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.RoleGroup).WithMany(g => g.PermissionSets).HasForeignKey(bc => bc.PermissionSetId).OnDelete(DeleteBehavior.Cascade);
        }
    }
    
}
