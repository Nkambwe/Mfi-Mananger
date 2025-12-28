using MfiManager.Middleware.Data.Entities.Operations.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlSavingProductEntityConfiguration {

        public static void Configure(EntityTypeBuilder<SavingProduct> builder) {
            builder.ToTable("TBL_MFI_SAVING_PRODUCT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("product_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ProductName).HasColumnName("product_name").HasColumnType("NVARCHAR(250)").IsRequired();
            builder.Property(p => p.IsActive).HasColumnName("is_active");
            builder.Property(p => p.VatInclusive).HasColumnName("vat_inclusive");
            builder.Property(p => p.UseChargeGroups).HasColumnName("use_charge_groups");
            builder.Property(p => p.LimitWithdraw).HasColumnName("limit_wihdraw");
            builder.Property(p => p.MaximumWithdraws).HasColumnName("max_wihdraw");
            builder.Property(p => p.WithdrawPenalty).HasColumnName("wihdraw_penality").HasPrecision(9,2);
            builder.Property(p => p.ChargeWithdraws).HasColumnName("charge_wihdraw");
            builder.Property(p => p.AllowOverdraft).HasColumnName("allow_overdraft");
            builder.Property(p => p.OverdraftInterest).HasColumnName("overdraft_interest").HasPrecision(9,2);
            builder.Property(p => p.MinimumBalance).HasColumnName("min_balance").HasPrecision(9,2);
            builder.Property(p => p.OfferInterest).HasColumnName("offer_interest");
            builder.Property(p => p.InterestRate).HasColumnName("int_rate").HasPrecision(9,2);
            builder.Property(p => p.MinimumInterestOffered).HasColumnName("minint_offered").HasPrecision(9,2);
            builder.Property(p => p.ProductTypeId).HasColumnName("product_type_id");
            builder.Property(p => p.ChargeGroupId).HasColumnName("charge_group_id").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.ProductType).WithMany(o => o.SavingProducts).HasForeignKey(mp => mp.ProductTypeId);
            builder.HasOne(m => m.ChargeGroup).WithMany(o => o.SavingProducts).HasForeignKey(mp => mp.ChargeGroupId);
            builder.HasMany(m => m.ChargedItems).WithOne(o => o.SavingProduct).HasForeignKey(mp => mp.SavingProductId);
            builder.HasMany(m => m.TaxableItems).WithOne(o => o.SavingProduct).HasForeignKey(mp => mp.SavingProductId);
            builder.HasMany(m => m.TaxGroups).WithOne(o => o.SavingProduct).HasForeignKey(mp => mp.SavingProductId);
            builder.HasMany(m => m.ProductParams).WithOne(o => o.SavingProduct).HasForeignKey(mp => mp.SavingProductId);
            builder.HasMany(m => m.WithdrawClasses).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
        }
    }

}
