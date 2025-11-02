using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.PostgreSql {
    public class PsqlEntityEntityConfiguration {
  
        public static void Configure(EntityTypeBuilder<MfiEntity> builder) {
            builder.ToTable("mfientities", "public");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("nextval('mfientity_seq')").HasColumnName("id");
            builder.Property(e => e.EntityName).HasColumnName("entity_name").HasColumnType("VARCHAR(200)").IsRequired();
            builder.Property(e => e.SecuredFields).HasColumnName("ip_address").HasColumnType("TEXT").IsRequired();

            builder.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            builder.Property(e => e.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(e => e.CreatedBy).HasColumnName("created_by").HasColumnType("VARCHAR(10)").IsRequired();
            builder.Property(e => e.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasColumnType("VARCHAR(10)").IsRequired(false);

            builder.HasMany(e => e.Logs).WithOne(e => e.Entity).HasForeignKey(a => a.EntityId);
        }
        
     }

}
