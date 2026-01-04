using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.PostgreSql {
    public class PsqlRoleGroupEntityConfiguration {

        public static void Configure(EntityTypeBuilder<RoleGroup> builder) {
            builder.ToTable("rolegroups", "public");
            builder.HasKey(g => g.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("nextval('rolegroup_seq')").HasColumnName("id");
            builder.Property(e => e.GroupName).HasColumnName("group_name").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(a => a.Scope).HasColumnName("group_scope").HasConversion<int>().IsRequired();
            builder.Property(e => e.Department).HasColumnName("department").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(e => e.Description).HasColumnName("group_description").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(e => e.IsApproved).HasColumnName("is_approved");
            builder.Property(e => e.IsVerified).HasColumnName("is_verified");

            builder.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            builder.Property(e => e.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(e => e.CreatedBy).HasColumnName("created_by").HasColumnType("VARCHAR(10)").IsRequired();
            builder.Property(e => e.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasColumnType("VARCHAR(10)").IsRequired(false);

            builder.HasMany(g => g.Roles).WithOne(s => s.RoleGroup).HasForeignKey(a => a.GroupId);
        }

    }

}
