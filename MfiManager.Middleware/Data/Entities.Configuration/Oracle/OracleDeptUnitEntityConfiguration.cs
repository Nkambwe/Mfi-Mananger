using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.Oracle {

    public class OracleDeptUnitEntityConfiguration {

          public static void Configure(EntityTypeBuilder<DepartmentUnit> builder){
                builder.ToTable("DEPARTMENTUNITS");
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Id).HasDefaultValueSql("DEPARTMENTUNIT_SEQ.NEXTVAL");
                builder.Property(e => e.DepartmentId).IsRequired();
                builder.Property(e => e.UnitName).HasMaxLength(200).IsRequired();

                builder.ConfigureAuditFields();
          }
    }

}
