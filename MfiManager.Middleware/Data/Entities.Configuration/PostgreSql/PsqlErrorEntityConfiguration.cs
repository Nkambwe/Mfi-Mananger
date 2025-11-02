using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.PostgreSql {
    public class PsqlErrorEntityConfiguration {

        public static void Configure(EntityTypeBuilder<SystemError> builder) {
            builder.ToTable("Systemerrors", "public");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("nextval('Systemerror_seq')").HasColumnName("id");
            builder.Property(e => e.CompanyId).HasColumnName("company_id").IsRequired(false);
            builder.Property(e => e.Message).HasColumnName("error_message").HasColumnType("TEXT").IsRequired();
            builder.Property(e => e.Source).HasColumnName("error_source").HasColumnType("TEXT").IsRequired();
            builder.Property(e => e.Severity).HasColumnName("error_severity").HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(e => e.StackTrace).HasColumnName("stack_trace").HasColumnType("TEXT").IsRequired();
            builder.Property(e => e.Status).HasColumnName("error_status").HasColumnType("VARCHAR(50)").IsRequired();

            builder.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            builder.Property(e => e.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(e => e.CreatedBy).HasColumnName("created_by").HasColumnType("VARCHAR(10)").IsRequired();
            builder.Property(e => e.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasColumnType("VARCHAR(10)").IsRequired(false);
            builder.HasOne(e => e.Company).WithMany(c => c.SystemErrors).HasForeignKey(f => f.CompanyId);
        }

    }

}
