using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.Oracle {
    public class OracleQuickActionEntityConfiguration {

        public static void Configure(EntityTypeBuilder<UserQuickAction> builder) {
            builder.ToTable("USERQUICKACTIONS");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("ACTION_SEQ.NEXTVAL");

            builder.Property(e => e.UserId).IsRequired();
            builder.Property(e => e.Label).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Controller).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Action).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Area).HasMaxLength(100).IsRequired(false);

            builder.ConfigureAuditFields();
        }
    }

}
