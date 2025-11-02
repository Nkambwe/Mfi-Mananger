using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.PostgreSql {
    public class PsqlDeptUnitEntityConfiguration {

        public static void Configure(EntityTypeBuilder<DepartmentUnit> builder) {
            builder.ToTable("departmentunits", "public");
            builder.HasKey(u => u.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("nextval('departmentunit_seq')").HasColumnName("id");
            builder.Property(e => e.DepartmentId).HasColumnName("branch_id");
            builder.Property(e => e.UnitCode).HasColumnName("unit_code").HasColumnType("VARCHAR(10)").IsRequired();
            builder.Property(e => e.UnitName).HasColumnName("unit_name").HasColumnType("VARCHAR(250)").IsRequired();

            builder.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            builder.Property(e => e.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(e => e.CreatedBy).HasColumnName("created_by").HasColumnType("VARCHAR(10)").IsRequired();
            builder.Property(e => e.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasColumnType("VARCHAR(10)").IsRequired(false);

            builder.HasOne(u => u.Department).WithMany(d => d.Units).HasForeignKey(d => d.DepartmentId);
        }
    }

}
