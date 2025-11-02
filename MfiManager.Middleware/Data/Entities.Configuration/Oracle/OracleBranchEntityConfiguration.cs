using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.Oracle {

    public class OracleBranchEntityConfiguration {
         public static void Configure(EntityTypeBuilder<Branch> builder) {
            builder.ToTable("BRANCHES");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("BRANCH_SEQ.NEXTVAL");

            builder.Property(e => e.BranchCode).HasMaxLength(20).IsRequired();
            builder.Property(e => e.BranchName).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Address).HasColumnType("CLOB").IsRequired(false);
            builder.Property(e => e.PostalAddress).HasMaxLength(200).IsRequired(false);
            builder.Property(e => e.EmailAddress).HasMaxLength(200).IsRequired(false);
            builder.Property(e => e.CompanyId).IsRequired();

            builder.ConfigureAuditFields();
         }
    }

}
