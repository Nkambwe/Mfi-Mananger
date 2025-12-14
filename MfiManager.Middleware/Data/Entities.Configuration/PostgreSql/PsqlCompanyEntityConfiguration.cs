using MfiManager.Middleware.Data.Entities.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.PostgreSql {

    public class PsqlCompanyEntityConfiguration {
        public static void Configure(EntityTypeBuilder<Company> builder) {
            builder.ToTable("companies", "public");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("nextval('company_seq')").HasColumnName("id");
            builder.Property(e => e.CompanyName).HasColumnName("company_name").HasColumnType("VARCHAR(200)").IsRequired();
            builder.Property(e => e.ShortName).HasColumnName("company_alias").HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(e => e.RegistrationNumber).HasColumnName("reg_number").HasColumnType("VARCHAR(50)");
            builder.Property(e => e.SystemLanguage).HasColumnName("lang").HasColumnType("VARCHAR(10)");
            builder.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            builder.Property(e => e.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(e => e.CreatedBy).HasColumnName("created_by").HasColumnType("VARCHAR(10)").IsRequired();
            builder.Property(e => e.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasColumnType("VARCHAR(10)").IsRequired(false);

            builder.HasMany(e => e.Branches).WithOne(b => b.Company).HasForeignKey(b => b.CompanyId);
            builder.HasMany(e => e.Departments).WithOne(d => d.Company).HasForeignKey(d => d.CompanyId);
            builder.HasMany(e => e.SystemConfigurations).WithOne(c => c.Company).HasForeignKey(c => c.CompanyId);
        }
    }


}
