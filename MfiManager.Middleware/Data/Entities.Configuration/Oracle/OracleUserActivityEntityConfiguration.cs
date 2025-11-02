using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.Oracle {
    public class OracleUserActivityEntityConfiguration {

        public static void Configure(EntityTypeBuilder<UserActivity> builder) {
            builder.ToTable("USERACTIVITIES");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("ACTIVITY_SEQ.NEXTVAL");
            builder.Property(e => e.Name).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Description).HasColumnType("CLOB").IsRequired(false);
            builder.Property(e => e.Category).HasConversion<int>().HasColumnName("CATEGORY").IsRequired();

            builder.ConfigureAuditFields();
        }
    }

}
