using MfiManager.Middleware.Data.Entities.Operations.Branches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlBranchCostCenterEntityConfiguration {

        public static void Configure(EntityTypeBuilder<BranchCostCenter> builder) {
            builder.ToTable("TBL_MFI_BRANCH_COSTCENTER");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Series).HasColumnName("cc_series").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.Name).HasColumnName("cc_name").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.Suspend).HasColumnName("is_suspended");
            builder.Property(p => p.FromDate).HasColumnName("from_date").IsRequired(false);
            builder.Property(p => p.ToDate).HasColumnName("to_date").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.BranchId).HasColumnName("branch_id");
            builder.HasOne(m => m.Branch).WithMany(o => o.CostCenters).HasForeignKey(mp => mp.BranchId);
        }
    }
}
