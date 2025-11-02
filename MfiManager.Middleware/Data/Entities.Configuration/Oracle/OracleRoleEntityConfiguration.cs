using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.Oracle {

    public class OracleRoleEntityConfiguration {

        public static void Configure(EntityTypeBuilder<SystemRole> builder) {
            builder.ToTable("SYSTEMROLES");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("ROLE_SEQ.NEXTVAL");
            builder.Property(e => e.RoleName).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Description).HasColumnType("CLOB").IsRequired(false);
            builder.Property(e => e.GroupId).IsRequired();
            builder.Property(e => e.IsApproved).IsRequired(false);
            builder.Property(e => e.IsVerified).IsRequired(false);

            builder.ConfigureAuditFields();
        }
    }

}
