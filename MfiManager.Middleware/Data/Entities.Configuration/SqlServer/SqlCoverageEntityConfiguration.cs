using MfiManager.Middleware.Data.Entities.Operations.Insurance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlCoverageEntityConfiguration {
        public static void Configure(EntityTypeBuilder<Coverage> builder) {
            builder.ToTable("TBL_MFI_COVERAGE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.CoverageName).HasColumnName("coverage_name").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.PercentagePremiumAmount).HasColumnName("percentage_premium_amount").HasPrecision(9,2);
            builder.Property(p => p.PremiumAmountIsFixed).HasColumnName("is_fixed_amount");
            builder.Property(p => p.FixedPremiumAmount).HasColumnName("fixed_premium_amount").HasPrecision(9,2);
            builder.Property(p => p.MinimumCoverageAmount).HasColumnName("min_coverage_amount").HasPrecision(9,2);
            builder.Property(p => p.MaximumCoverageAmount).HasColumnName("max_coverage_amount").HasPrecision(9,2);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(m => m.InsuranceProducts).WithOne(o => o.Coverage).HasForeignKey(mp => mp.CoverageId);
            builder.HasMany(m => m.CoveredItems).WithOne(o => o.Coverage).HasForeignKey(mp => mp.CoverageId);
        }
     }
}
