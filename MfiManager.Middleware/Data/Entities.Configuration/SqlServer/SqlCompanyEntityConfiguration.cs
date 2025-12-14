using MfiManager.Middleware.Data.Entities.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlCompanyEntityConfiguration {
        public static void Configure(EntityTypeBuilder<Company> builder) {
            builder.ToTable("TBL_MFI_COMPANY");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("id");
            builder.Property(c => c.CompanyName).HasColumnName("company_name").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(c => c.ShortName).HasColumnName("alias").HasColumnType("NVARCHAR(50)").IsRequired();
            builder.Property(c => c.RegistrationNumber).HasColumnName("reg_number").HasColumnType("NVARCHAR(50)");
            builder.Property(c => c.SystemLanguage).HasColumnName("language").HasColumnType("NVARCHAR(50)");
            builder.Property(c => c.IsDeleted).HasColumnName("is_deleted");
            builder.Property(c => c.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(c => c.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(c => c.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(c => c.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);

            builder.HasMany(c => c.SystemErrors).WithOne(e => e.Company).HasForeignKey(e => e.CompanyId);
            builder.HasMany(c => c.Departments).WithOne(d => d.Company).HasForeignKey(d => d.CompanyId);
            builder.HasMany(c => c.Branches).WithOne(b => b.Company).HasForeignKey(b => b.CompanyId);
            builder.HasMany(c => c.SystemConfigurations).WithOne(s => s.Company).HasForeignKey(s => s.CompanyId);
        }
    }
}
