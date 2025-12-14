using MfiManager.Middleware.Data.Entities.Operations.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlTimedepositProductEntityConfiguration {

        public static void Configure(EntityTypeBuilder<TimedepositProduct> builder) {
            builder.ToTable("TBL_MFI_TIMEDEPOSIT_PRODUCT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.WithdrawMode).HasColumnName("int_wihdraw_mode");
            builder.Property(p => p.CapitalizeInterest).HasColumnName("cap_interest");
            builder.Property(p => p.ForfeitInterestForPrematureWithdraw).HasColumnName("forfeit_interest");
            builder.Property(p => p.PrematureWithdrawsPenalty).HasColumnName("prem_wihdraw_penality").HasPrecision(9,2);
            builder.Property(p => p.Period).HasColumnName("period");
            builder.Property(p => p.PeriodType).HasColumnName("period_type");
            builder.Property(p => p.MinimumAmount).HasColumnName("min_amount").HasPrecision(9,2);
            builder.Property(p => p.MaximumAmount).HasColumnName("max_balance").HasPrecision(9,2);
            builder.Property(p => p.TierInterest).HasColumnName("tier_interest");
            builder.Property(p => p.TierMethod).HasColumnName("tier_method");
            builder.Property(p => p.ProductId).HasColumnName("product_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Product).WithMany(o => o.TimedepositProducts).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.InterestRates).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.TimedepositAccounts).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
        }
    }

}
