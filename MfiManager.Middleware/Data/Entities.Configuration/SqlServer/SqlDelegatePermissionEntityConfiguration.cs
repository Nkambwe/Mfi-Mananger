using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlDelegatePermissionEntityConfiguration {

        public static void Configure(EntityTypeBuilder<DelegatePermission> builder) {
            builder.ToTable("TBL_MFI_PERMISSION_DELEGATES");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Revoke).HasColumnName("is_revoke");
            builder.Property(p => p.StartDate).HasColumnName("start_date").IsRequired();
            builder.Property(p => p.ExpiryDate).HasColumnName("expiry_date").IsRequired(false);
            builder.Property(p => p.PermissionId).HasColumnName("permission_id");
            builder.Property(p => p.SystemUserId).HasColumnName("user_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.SystemUser).WithMany(e => e.DelegatePermissions).HasForeignKey(e => e.SystemUserId);
            builder.HasOne(p => p.Pemission).WithMany(e => e.DelegatePermissions).HasForeignKey(e => e.PermissionId);
        }
    }
    
}
