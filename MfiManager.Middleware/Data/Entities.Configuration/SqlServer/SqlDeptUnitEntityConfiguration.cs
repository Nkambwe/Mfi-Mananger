using MfiManager.Middleware.Data.Entities.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlDeptUnitEntityConfiguration {
        public static void Configure(EntityTypeBuilder<DepartmentUnit> builder) {
            builder.ToTable("TBL_MFI_DEPTUNIT");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id).HasColumnName("id");
            builder.Property(u => u.DepartmentId).HasColumnName("department_id"); // FIXED
            builder.Property(u => u.UnitCode).HasColumnName("unit_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(u => u.UnitName).HasColumnName("unit_name").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(u => u.IsDeleted).HasColumnName("is_deleted");
            builder.Property(u => u.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(u => u.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(u => u.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(u => u.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);

            builder.HasOne(u => u.Department).WithMany(d => d.Units).HasForeignKey(u => u.DepartmentId);
        }
    }

}
