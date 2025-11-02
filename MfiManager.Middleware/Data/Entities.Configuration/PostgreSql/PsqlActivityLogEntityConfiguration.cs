using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.PostgreSql {
    public class PsqlActivityLogEntityConfiguration {
  
        public static void Configure(EntityTypeBuilder<UserActivityLog> builder) {
            builder.ToTable("activitylogs", "public");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasDefaultValueSql("nextval('activitylog_seq')").HasColumnName("id");
            builder.Property(b => b.UserId).HasColumnName("user_id").IsRequired();
            builder.Property(b => b.ActivityId).HasColumnName("activity_id").IsRequired();
            builder.Property(b => b.EntityId).HasColumnName("entity_id").IsRequired();
            builder.Property(b => b.ActionDetails).HasColumnName("address").HasColumnType("TEXT").IsRequired(false);
            builder.Property(b => b.IpAddress).HasColumnName("ip_address").HasColumnType("VARCHAR(20)").IsRequired(false);
            builder.Property(b => b.IsDeleted).HasColumnName("is_deleted");
            builder.Property(b => b.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(b => b.CreatedBy).HasColumnName("created_by").HasColumnType("VARCHAR(10)").IsRequired();
            builder.Property(b => b.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(b => b.ModifiedBy).HasColumnName("modified_by").HasColumnType("VARCHAR(10)").IsRequired(false);
            builder.HasOne(l => l.User).WithMany(u => u.ActivityLogs).HasForeignKey(u => u.UserId);
            builder.HasOne(l => l.Activity).WithMany(a => a.UserActivityLogs).HasForeignKey(a => a.ActivityId);
            builder.HasOne(l => l.Entity).WithMany(e => e.Logs).HasForeignKey(a => a.EntityId);
        }
        
     }
}
