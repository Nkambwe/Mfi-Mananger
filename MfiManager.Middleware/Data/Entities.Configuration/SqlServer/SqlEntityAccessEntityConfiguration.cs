using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlEntityAccessEntityConfiguration {

        public static void Configure(EntityTypeBuilder<EntityAccess> builder) {
            builder.ToTable("TBL_MFI_ENTITY_ACCESS");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.EntityName).HasColumnName("entity_name").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.CanRead).HasColumnName("can_read");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.BranchId).HasColumnName("branch_id");
            builder.HasOne(m => m.Branch).WithMany(o => o.Entities).HasForeignKey(mp => mp.BranchId);
        }
    }

}
