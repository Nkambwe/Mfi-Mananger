using MfiManager.Middleware.Data.Entities.Operations.Timedeposit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlInterestTierEntityConfiguration {

        public static void Configure(EntityTypeBuilder<InterestTier> builder) {
            builder.ToTable("TBL_MFI_TIMEDEPOSIT_INTEREST_TIER");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.LowerTier).HasColumnName("lower_tier").HasPrecision(9,2);
            builder.Property(p => p.UpperTier).HasColumnName("upper_tier").HasPrecision(9,2);
            builder.Property(p => p.TierRate).HasColumnName("tier_rate").HasPrecision(9,2);
            builder.Property(p => p.ProductId).HasColumnName("product_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Product).WithMany(e => e.InterestTiers).HasForeignKey(e => e.ProductId);
        }
    }

}
