using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.Oracle {
    public class OracleRoleGroupEntityConfiguration {

        public static void Configure(EntityTypeBuilder<RoleGroup> builder) {
            builder.ToTable("ROLEGROUPS");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("ROLEGROUP_SEQ.NEXTVAL");
            builder.Property(e => e.GroupName).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(250).IsRequired();
            builder.Property(e => e.Scope).HasConversion<int>().HasColumnName("SCOPE").IsRequired();
            builder.Property(e => e.Department).HasMaxLength(200).IsRequired();
            builder.Property(e => e.IsApproved).IsRequired(false);
            builder.Property(e => e.IsVerified).IsRequired(false);
            
            builder.ConfigureAuditFields();
        }
    }

}
