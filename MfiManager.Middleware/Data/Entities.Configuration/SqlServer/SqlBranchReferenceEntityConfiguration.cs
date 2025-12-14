using MfiManager.Middleware.Data.Entities.Operations.Branches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlBranchReferenceEntityConfiguration {

        public static void Configure(EntityTypeBuilder<BranchReference> builder) {
            builder.ToTable("TBL_MFI_BRANCH_REFERENCE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("value_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.Description).HasColumnName("value_description").HasColumnType("NVARCHAR(40)").IsRequired();
            builder.Property(p => p.Suspend).HasColumnName("is_suspended");
            builder.Property(p => p.Start).HasColumnName("start_date").IsRequired(false);
            builder.Property(p => p.End).HasColumnName("end_date").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.ReferenceValue).WithMany(o => o.BranchReferences).HasForeignKey(mp => mp.ReferenceValueId);
        }
    }
}
