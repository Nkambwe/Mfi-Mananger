using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.PostgreSql {
    public class PsqlSystemConfigEntityConfiguration {

        public static void Configure(EntityTypeBuilder<SystemConfiguration> builder) {
            builder.ToTable("sysconfigs", "public");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("nextval('Sysconfig_seq')").HasColumnName("id");
            builder.Property(e => e.CompanyId).HasColumnName("company_id").IsRequired(false);
            builder.Property(e => e.BranchId).HasColumnName("branch_id").IsRequired(false);
            builder.Property(e => e.ParameterName).HasColumnName("parameter_name").HasColumnType("TEXT").IsRequired();
            builder.Property(e => e.ParameterValue).HasColumnName("parameter_value").HasColumnType("TEXT").IsRequired();
            builder.Property(e => e.Description).HasColumnName("param_description").HasColumnType("TEXT").IsRequired();

            builder.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            builder.Property(e => e.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(e => e.CreatedBy).HasColumnName("created_by").HasColumnType("VARCHAR(10)").IsRequired();
            builder.Property(e => e.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasColumnType("VARCHAR(10)").IsRequired(false);

            builder.HasOne(f => f.Branch).WithMany(b => b.SystemConfigurations).HasForeignKey(f => f.BranchId);
            builder.HasOne(f => f.Company).WithMany(c => c.SystemConfigurations).HasForeignKey(f => f.CompanyId);
        }

    }

}
