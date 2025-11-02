using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlEntityEntityConfiguration {
  
        public static void Configure(EntityTypeBuilder<MfiEntity> builder) {
            builder.ToTable("TBL_MFI_ENTITY");
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).HasColumnName("id");
            builder.Property(l => l.EntityName).HasColumnName("entity_name").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(l => l.SecuredFields).HasColumnName("ip_address").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(l => l.IsDeleted).HasColumnName("is_deleted");
            builder.Property(l => l.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(l => l.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(l => l.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(l => l.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(l => l.Logs).WithOne(e => e.Entity).HasForeignKey(a => a.EntityId);
        }
        
     }

}
