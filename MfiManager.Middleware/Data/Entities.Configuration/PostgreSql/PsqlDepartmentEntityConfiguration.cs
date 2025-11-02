using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.PostgreSql {
    public class PsqlDepartmentEntityConfiguration {

        public static void Configure(EntityTypeBuilder<Department> builder) {
            builder.ToTable("departments", "public");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("nextval('department_seq')").HasColumnName("id");
            builder.Property(e => e.CompanyId).HasColumnName("company_id").IsRequired();
            builder.Property(e => e.DepartmenCode).HasColumnName("address").HasColumnType("VARCHAR(10)").IsRequired(false);
            builder.Property(e => e.DepartmentName).HasColumnName("ip_address").HasColumnType("VARCHAR(250)").IsRequired(false);
            builder.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            builder.Property(e => e.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(e => e.CreatedBy).HasColumnName("created_by").HasColumnType("VARCHAR(10)").IsRequired();
            builder.Property(e => e.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasColumnType("VARCHAR(10)").IsRequired(false);
            builder.HasOne(e => e.Company).WithMany(c => c.Departments).HasForeignKey(b => b.CompanyId);
            builder.HasMany(e => e.Users).WithOne(u => u.Department).HasForeignKey(u => u.DepartmentId);
            builder.HasMany(e => e.Units).WithOne(u => u.Department).HasForeignKey(u => u.DepartmentId);
        }
    }

}
