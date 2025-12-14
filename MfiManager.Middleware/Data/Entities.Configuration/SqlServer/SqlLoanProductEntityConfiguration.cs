using MfiManager.Middleware.Data.Entities.Operations.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlLoanProductEntityConfiguration {

        public static void Configure(EntityTypeBuilder<LoanProduct> builder) {
            builder.ToTable("TBL_MFI_LOAN_PRODUCT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ProductId).HasColumnName("product_id");
            builder.Property(p => p.Target).HasColumnName("loan_target");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.SectorId).HasColumnName("sector_id");
            builder.Property(p => p.FundId).HasColumnName("fund_id");
            builder.HasOne(m => m.Sector).WithMany(o => o.LoanProducts).HasForeignKey(mp => mp.SectorId);
            builder.HasOne(m => m.Fund).WithMany(o => o.LoanProducts).HasForeignKey(mp => mp.FundId);
            builder.HasOne(m => m.Product).WithMany(o => o.LoanProducts).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.AdjustedRates).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.FeesPaymentLevels).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.Loans).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.AgingClasses).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.Penalties).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
        }
    }
}
