using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {

    public class SqlRoleEntityConfiguration {

        public static void Configure(EntityTypeBuilder<SystemRole> builder) {
            builder.ToTable("TBL_MFI_ROLE");
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id).HasColumnName("id");
            builder.Property(r => r.GroupId).HasColumnName("group_id");
            builder.Property(r => r.RoleName).HasColumnName("role_name").HasColumnType("NVARCHAR(100)").IsRequired();
            builder.Property(r => r.Description).HasColumnName("role_description").HasColumnType("NVARCHAR(500)").IsRequired(false);
            builder.Property(r => r.IsDeleted).HasColumnName("is_deleted");
            builder.Property(r => r.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(r => r.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(r => r.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(r => r.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);

            builder.HasOne(r => r.Group).WithMany(g => g.Roles).HasForeignKey(r => r.GroupId);
        }
    }
}
