using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.PostgreSql {
    public class PsqlUserActivityEntityConfiguration {

        public static void Configure(EntityTypeBuilder<UserActivity> builder) {
            builder.ToTable("activities", "public");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("nextval('activity_seq')").HasColumnName("id");
            builder.Property(e => e.Name).HasColumnName("user_activity").HasColumnType("VARCHAR(250)");
            builder.Property(e => e.SystemKeyword).HasColumnName("system_keyword").HasColumnType("TEXT").IsRequired();
            builder.Property(e => e.Description).HasColumnName("css_class").HasColumnType("TEXT").IsRequired();
            builder.Property(e => e.Category).HasColumnName("category").HasConversion<int>() .IsRequired();
            builder.Property(e => e.Enabled).HasColumnName("is_enabled");
            builder.Property(e => e.IsAdminActivity).HasColumnName("is_admin_activity");

            builder.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            builder.Property(e => e.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(e => e.CreatedBy).HasColumnName("created_by").HasColumnType("VARCHAR(10)").IsRequired();
            builder.Property(e => e.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasColumnType("VARCHAR(10)").IsRequired(false);

            builder.HasMany(a => a.UserActivityLogs).WithOne(c => c.Activity).HasForeignKey(a => a.ActivityId);
        }

    }

}
