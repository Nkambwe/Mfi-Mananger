using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlPermissionSetPermissionsEntityConfiguration {

        public static void Configure(EntityTypeBuilder<PermissionSetPermissions> builder) {
            builder.ToTable("TBL_MFI_PERMISSIONSET_PERMISSION");
            builder.HasKey(bc => new { bc.PermissionSetId, bc.PermissionId });
            builder.Property(bc => bc.PermissionSetId).HasColumnName("permission_set_id").IsRequired();
            builder.Property(bc => bc.PermissionId).HasColumnName("permission_id").IsRequired();
            builder.HasOne(bc => bc.PermissionSet).WithMany(p => p.Permissions).HasForeignKey(bc => bc.PermissionId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Permission).WithMany(g => g.PermissionSets).HasForeignKey(bc => bc.PermissionSetId).OnDelete(DeleteBehavior.Cascade);
        }
    }
    
}
