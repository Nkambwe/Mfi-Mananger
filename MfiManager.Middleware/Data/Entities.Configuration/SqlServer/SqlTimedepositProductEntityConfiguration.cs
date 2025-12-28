using MfiManager.Middleware.Data.Entities.Operations.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlTimedepositProductEntityConfiguration {

        public static void Configure(EntityTypeBuilder<TimedepositProduct> builder) {
            builder.ToTable("TBL_MFI_TIMEDEPOSIT_PRODUCT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("product_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ProductName).HasColumnName("product_name").HasColumnType("NVARCHAR(250)").IsRequired();
            builder.Property(p => p.WithdrawMode).HasColumnName("wd_mode");
            builder.Property(p => p.IsActive).HasColumnName("is_active");
            builder.Property(p => p.VatInclusive).HasColumnName("vat_inclusive");
            builder.Property(p => p.UseChargeGroups).HasColumnName("use_charge_groups");
            builder.Property(p => p.ProductTypeId).HasColumnName("product_type_id");
            builder.Property(p => p.ChargeGroupId).HasColumnName("charge_group_id").IsRequired(false);
            builder.Property(p => p.CapitalizeInterest).HasColumnName("cap_interest");
            builder.Property(p => p.ForfeitInterestForPrematureWithdraw).HasColumnName("forfeit_interest");
            builder.Property(p => p.PrematureWithdrawsPenalty).HasColumnName("prem_wihdraw_penality").HasPrecision(9,2);
            builder.Property(p => p.Period).HasColumnName("period");
            builder.Property(p => p.PeriodType).HasColumnName("period_type");
            builder.Property(p => p.MinimumAmount).HasColumnName("min_amount").HasPrecision(9,2);
            builder.Property(p => p.MaximumAmount).HasColumnName("max_balance").HasPrecision(9,2);
            builder.Property(p => p.TierInterest).HasColumnName("tier_interest");
            builder.Property(p => p.TierMethod).HasColumnName("tier_method");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(m => m.TimedepositAccounts).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
            builder.HasOne(m => m.ProductType).WithMany(o => o.TimedepositProducts).HasForeignKey(mp => mp.ProductTypeId);
            builder.HasOne(m => m.ChargeGroup).WithMany(o => o.TimedepositProducts).HasForeignKey(mp => mp.ChargeGroupId);
            builder.HasMany(m => m.ChargedItems).WithOne(o => o.TimedepositProduct).HasForeignKey(mp => mp.TimedepositProductId);
            builder.HasMany(m => m.TaxableItems).WithOne(o => o.TimedepositProduct).HasForeignKey(mp => mp.TimedepositProductId);
            builder.HasMany(m => m.ProductParams).WithOne(o => o.TimedepositProduct).HasForeignKey(mp => mp.TimedepositProductId);
            builder.HasMany(m => m.TaxGroups).WithOne(o => o.TimedepositProduct).HasForeignKey(mp => mp.TimedepositProductId);
            builder.HasMany(m => m.InterestRates).WithOne(o => o.TimedepositProduct).HasForeignKey(mp => mp.TimedepositProductId);
            
        }
    }

}
