using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.PostgreSql {
    public class PsqlRoleEntityConfiguration {
        public static void Configure(EntityTypeBuilder<SystemRole> builder) {
            builder.ToTable("roles", "public");
            builder.HasKey(r => r.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("nextval('role_seq')").HasColumnName("id");
            builder.Property(r => r.GroupId).HasColumnName("group_id");
            builder.Property(r => r.RoleName).HasColumnName("role_name").HasColumnType("VARCHAR(250)").IsRequired();
            builder.Property(r => r.Description).HasColumnName("role_description").HasColumnType("TEXT").IsRequired();

            builder.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            builder.Property(e => e.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(e => e.CreatedBy).HasColumnName("created_by").HasColumnType("VARCHAR(10)").IsRequired();
            builder.Property(e => e.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasColumnType("VARCHAR(10)").IsRequired(false);

            builder.HasOne(r => r.RoleGroup).WithMany(c => c.Roles).HasForeignKey(b => b.GroupId);
        }
    }

}
