using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlActivityLogEntityConfiguration {
        public static void Configure(EntityTypeBuilder<UserActivityLog> builder) {
            builder.ToTable("TBL_MFI_ACTIVITY_LOG");
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Id).HasColumnName("id");
            builder.Property(l => l.UserId).HasColumnName("user_id");
            builder.Property(l => l.ActivityId).HasColumnName("activity_id");
            builder.Property(l => l.EntityId).HasColumnName("entity_id");
            builder.Property(l => l.ActionDetails).HasColumnName("action_details").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(l => l.IpAddress).HasColumnName("ip_address").HasColumnType("NVARCHAR(80)").IsRequired();
            builder.Property(l => l.IsDeleted).HasColumnName("is_deleted");
            builder.Property(l => l.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(l => l.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(l => l.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(l => l.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);

            builder.HasOne(l => l.User).WithMany(u => u.ActivityLogs).HasForeignKey(l => l.UserId);
            builder.HasOne(l => l.Activity).WithMany(a => a.UserActivityLogs).HasForeignKey(l => l.ActivityId);
            builder.HasOne(l => l.Entity).WithMany(e => e.Logs).HasForeignKey(l => l.EntityId);
        }
    }

}
