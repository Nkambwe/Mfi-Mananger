using MfiManager.Middleware.Data.Entities.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.Oracle {

    public class OracleDepartmentEntityConfiguration {
         public static void Configure(EntityTypeBuilder<Department> builder) {
            builder.ToTable("DEPARTMENTS");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("DEPARTMENT_SEQ.NEXTVAL");
            builder.Property(e => e.CompanyId).IsRequired();
            builder.Property(e => e.DepartmentName).HasMaxLength(200).IsRequired();

            builder.ConfigureAuditFields();
         }
    }

}
