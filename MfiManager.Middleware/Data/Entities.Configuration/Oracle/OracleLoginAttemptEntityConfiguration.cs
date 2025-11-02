using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.Oracle {
    public class OracleLoginAttemptEntityConfiguration {

        public static void Configure(EntityTypeBuilder<LoginAttempt> builder) {
            builder.ToTable("LOGINATTEMPTS");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("ATTEMPTS_SEQ.NEXTVAL");

            builder.Property(e => e.UserId).IsRequired();
            builder.Property(e => e.IpAddress).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Successful).IsRequired();
            builder.Property(e => e.LoginDate).IsRequired();

            builder.ConfigureAuditFields();
        }
    }

}
