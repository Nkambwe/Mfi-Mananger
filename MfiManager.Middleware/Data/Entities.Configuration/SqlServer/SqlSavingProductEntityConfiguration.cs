using MfiManager.Middleware.Data.Entities.Operations.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlSavingProductEntityConfiguration {

        public static void Configure(EntityTypeBuilder<SavingProduct> builder) {
            builder.ToTable("TBL_MFI_SAVING_PRODUCT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
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
            builder.Property(p => p.ProductId).HasColumnName("product_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Product).WithMany(o => o.SavingProducts).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.WithdrawClasses).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
        }
    }

}
