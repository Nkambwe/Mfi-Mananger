using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.System {
    public class CompanyEntityConfiguration {

        public static void Configure(EntityTypeBuilder<Company> builder) {
            builder.ToTable("TBL_MFI_COMPANY");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CompanyName).HasColumnName("company_name").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(c => c.ShortName).HasColumnName("alias").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(c => c.RegistrationNumber).HasColumnName("reg_number").HasColumnType("NVARCHAR(MAX)");
            builder.Property(c => c.SystemLanguage).HasColumnName("language").HasColumnType("NVARCHAR(MAX)");
            builder.Property(c => c.IsDeleted).HasColumnName("is_Deleted");
            builder.Property(c => c.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(c => c.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(c => c.ModifiedOn).HasColumnName("modefied_on").IsRequired(false);
            builder.Property(c => c.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(c => c.SystemErrors).WithOne(a => a.Company).HasForeignKey(a => a.CompanyId);
            builder.HasMany(c => c.Departments).WithOne(a => a.Company).HasForeignKey(a => a.CompanyId);
            builder.HasMany(c => c.Branches).WithOne(b => b.Company).HasForeignKey(b => b.CompanyId);
            builder.HasMany(c => c.SystemConfigurations).WithOne(a => a.Company).HasForeignKey(a => a.CompanyId);
        }
    }
}
