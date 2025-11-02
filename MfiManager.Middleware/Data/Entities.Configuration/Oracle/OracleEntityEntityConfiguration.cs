using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.Oracle {

    public class OracleEntityEntityConfiguration {

         public static void Configure(EntityTypeBuilder<MfiEntity> builder) {
            builder.ToTable("MFIENTITIES");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("ENTITY_SEQ.NEXTVAL");
            builder.Property(e => e.EntityName).HasMaxLength(200).IsRequired();
            builder.Property(e => e.SecuredFields).HasColumnType("CLOB").IsRequired(false);

            builder.ConfigureAuditFields();
         }
    }

}
