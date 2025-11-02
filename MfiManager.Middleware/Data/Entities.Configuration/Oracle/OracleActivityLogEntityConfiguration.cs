using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.Oracle {

    public class OracleActivityLogEntityConfiguration {

        public static void Configure(EntityTypeBuilder<UserActivityLog> builder) {
            builder.ToTable("ACTIVITYLOGS");
            builder.HasKey(l => l.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("ACTIVITYLOG_SEQ.NEXTVAL");
            builder.Property(e => e.UserId).IsRequired();
            builder.Property(e => e.ActivityId).IsRequired();
            builder.Property(e => e.EntityId).IsRequired();
            builder.Property(e => e.ActionDetails).HasMaxLength(int.MaxValue).IsRequired();
            builder.Property(e => e.IpAddress).HasMaxLength(20).IsRequired(false);
            
            builder.ConfigureAuditFields();

        }
    }
}
