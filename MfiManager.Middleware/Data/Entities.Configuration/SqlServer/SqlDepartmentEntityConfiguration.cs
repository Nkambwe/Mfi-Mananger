using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlDepartmentEntityConfiguration {
        public static void Configure(EntityTypeBuilder<Department> builder) {
            builder.ToTable("TBL_MFI_DEPARTMENT");
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id).HasColumnName("id");
            builder.Property(d => d.CompanyId).HasColumnName("company_id");
            builder.Property(d => d.DepartmenCode).HasColumnName("dept_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(d => d.DepartmentName).HasColumnName("dept_name").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(d => d.IsDeleted).HasColumnName("is_deleted");
            builder.Property(d => d.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(d => d.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(d => d.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(d => d.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);

            builder.HasOne(d => d.Company).WithMany(c => c.Departments).HasForeignKey(d => d.CompanyId);
            builder.HasMany(d => d.Users).WithOne(u => u.Department).HasForeignKey(u => u.DepartmentId);
            builder.HasMany(d => d.Units).WithOne(u => u.Department).HasForeignKey(u => u.DepartmentId);
        }
    }
}
