using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.Oracle {

    public class OracleCompanyEntityConfiguration {
        public static void Configure(EntityTypeBuilder<Company> builder) {
            builder.ToTable("COMPANIES");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("COMPANY_SEQ.NEXTVAL");
            builder.Property(e => e.CompanyName).HasMaxLength(200).IsRequired();
            builder.Property(e => e.ShortName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.RegistrationNumber).HasMaxLength(100).IsRequired();

            builder.ConfigureAuditFields();
        }
    }
}
