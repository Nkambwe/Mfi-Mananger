using MfiManager.Middleware.Data.Entities.Operations.Insurance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlCoverageItemEntityConfiguration {
        public static void Configure(EntityTypeBuilder<CoverageItem> builder) {
            builder.ToTable("TBL_MFI_COVERAGE_ITEM");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ItemName).HasColumnName("item_name").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.Amount).HasColumnName("coverage_amount").HasPrecision(9,2);
            builder.Property(p => p.ChargePerPerson).HasColumnName("charge_per_person");
            builder.Property(p => p.HasDeductable).HasColumnName("hadDeductable");
            builder.Property(p => p.DeductableAsPercentage).HasColumnName("is_percentage");
            builder.Property(p => p.DeductableRate).HasColumnName("percentage_rate").HasPrecision(9,2);
            builder.Property(p => p.FixedDeductableAmount).HasColumnName("fixed_amount").HasPrecision(9,2);
            builder.Property(p => p.CoverageId).HasColumnName("coverage_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.HasOne(m => m.Coverage).WithMany(o => o.CoveredItems).HasForeignKey(mp => mp.CoverageId);
        }
     }
}
