using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {

    public class SqlRoleGroupEntityConfiguration {

        public static void Configure(EntityTypeBuilder<RoleGroup> builder) {
            builder.ToTable("TBL_MFI_ROLE_GROUP");
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Id).HasColumnName("id");
            builder.Property(g => g.GroupName).HasColumnName("group_name").HasColumnType("NVARCHAR(100)").IsRequired();
            builder.Property(g => g.Scope).HasColumnName("group_scope").HasColumnType("INT").IsRequired();
            builder.Property(g => g.Department).HasColumnName("department").HasColumnType("NVARCHAR(50)").IsRequired(false);
            builder.Property(g => g.Description).HasColumnName("group_description").HasColumnType("NVARCHAR(500)").IsRequired(false);
            builder.Property(g => g.IsDeleted).HasColumnName("is_deleted");
            builder.Property(g => g.IsApproved).HasColumnName("is_approved");
            builder.Property(g => g.IsVerified).HasColumnName("is_verified");
            builder.Property(g => g.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(g => g.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(g => g.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(g => g.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(g => g.Roles).WithOne(r => r.RoleGroup).HasForeignKey(r => r.GroupId);
            builder.HasMany(g => g.PermissionSets).WithOne(r => r.RoleGroup).HasForeignKey(r => r.RoleGroupId);
        }
    }

}
