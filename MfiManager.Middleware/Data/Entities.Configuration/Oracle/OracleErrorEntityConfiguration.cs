using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.Oracle {
    public class OracleErrorEntityConfiguration {

        public static void Configure(EntityTypeBuilder<SystemError> builder) {
            builder.ToTable("SYSTEMERRORS");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("ERROR_SEQ.NEXTVAL");

            builder.Property(e => e.Message).HasColumnType("CLOB").IsRequired();
            builder.Property(e => e.Source).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Severity).HasMaxLength(100).IsRequired();
            builder.Property(e => e.StackTrace).HasColumnType("CLOB").IsRequired(false);
            builder.Property(e => e.Status).HasMaxLength(100).IsRequired(false);

            builder.ConfigureAuditFields();
        }
    }

}
