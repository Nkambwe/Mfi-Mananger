using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {

    public class SqlUserActivityEntityConfiguration {

        public static void Configure(EntityTypeBuilder<UserActivity> builder) {
            builder.ToTable("TBL_MFI_USER_ACTIVITY");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("id");
            builder.Property(a => a.Name).HasColumnName("activity_name").HasColumnType("NVARCHAR(100)").IsRequired();
            builder.Property(a => a.SystemKeyword).HasColumnName("system_keyword").HasColumnType("NVARCHAR(100)").IsRequired();
            builder.Property(a => a.Description).HasColumnName("description").HasColumnType("NVARCHAR(500)").IsRequired(false);
            builder.Property(a => a.Category).HasColumnName("category").HasColumnType("INT").IsRequired();
            builder.Property(a => a.Enabled).HasColumnName("is_enabled");
            builder.Property(a => a.IsAdminActivity).HasColumnName("is_admin_activity");
            builder.Property(a => a.IsDeleted).HasColumnName("is_deleted");
            builder.Property(a => a.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(a => a.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(a => a.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(a => a.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);

            builder.HasMany(a => a.UserActivityLogs).WithOne(l => l.Activity).HasForeignKey(l => l.ActivityId);
        }
    }
}
