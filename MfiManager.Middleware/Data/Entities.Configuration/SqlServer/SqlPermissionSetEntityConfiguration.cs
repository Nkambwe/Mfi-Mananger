using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlPermissionSetEntityConfiguration {

        public static void Configure(EntityTypeBuilder<PermissionSet> builder) {
            builder.ToTable("TBL_MFI_PERMISSION_SET");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Series).HasColumnName("series").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.Description).HasColumnName("description").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(p => p.SystemRoles).WithOne(e => e.PermissionSet).HasForeignKey(e => e.PermissionSetId);
            builder.HasMany(p => p.RoleGroups).WithOne(e => e.PermissionSet).HasForeignKey(e => e.PermissionSetId);
            builder.HasMany(p => p.Permissions).WithOne(e => e.PermissionSet).HasForeignKey(e => e.PermissionSetId);
        }
    }
    
}
