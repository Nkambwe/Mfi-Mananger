using MfiManager.Middleware.Data.Entities.System.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.Oracle {

    public class OracleSystemConfigEntityConfiguration {

        public static void Configure(EntityTypeBuilder<SystemParam> builder) {
            builder.ToTable("SYSTEMCONFIGS");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("CONFIG_SEQ.NEXTVAL");

            builder.Property(e => e.ParameterName).HasMaxLength(200).IsRequired();
            builder.Property(e => e.ParameterValue).HasColumnType("CLOB").IsRequired(false);
            builder.Property(e => e.Description).HasColumnType("CLOB").IsRequired(false);
            builder.Property(e => e.CompanyId).IsRequired(false);

            builder.ConfigureAuditFields();
        }
    }

}
