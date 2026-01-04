using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlSystemRolePermissionSetEntityConfiguration {

        public static void Configure(EntityTypeBuilder<SystemRolePermissionSet> builder) {
            builder.ToTable("TBL_MFI_SYSTEMROLE_PERMISSIONSET");
            builder.HasKey(bc => new { bc.PermissionSetId, bc.SystemRoleId });
            builder.Property(bc => bc.PermissionSetId).HasColumnName("permission_set_id").IsRequired();
            builder.Property(bc => bc.SystemRoleId).HasColumnName("sys_role_id").IsRequired();
            builder.HasOne(bc => bc.PermissionSet).WithMany(p => p.SystemRoles).HasForeignKey(bc => bc.SystemRoleId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.SystemRole).WithMany(g => g.PermissionSets).HasForeignKey(bc => bc.PermissionSetId).OnDelete(DeleteBehavior.Cascade);
        }
    }
    
}
