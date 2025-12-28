using MfiManager.Middleware.Data.Entities.Operations.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {

    public class SqlLoanProductEntityConfiguration {
        public static void Configure(EntityTypeBuilder<LoanProduct> builder) {
            builder.ToTable("TBL_MFI_LOAN_PRODUCT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("product_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ProductName).HasColumnName("product_name").HasColumnType("NVARCHAR(250)").IsRequired();
            builder.Property(p => p.IsActive).HasColumnName("is_active");
            builder.Property(p => p.VatInclusive).HasColumnName("vat_inclusive");
            builder.Property(p => p.UseChargeGroups).HasColumnName("use_charge_groups");
            builder.Property(p => p.ProductTypeId).HasColumnName("product_type_id");
            builder.Property(p => p.ChargeGroupId).HasColumnName("charge_group_id").IsRequired(false);
            builder.Property(p => p.TargetGroup).HasColumnName("loan_target");
            builder.Property(p => p.UseClasses).HasColumnName("use_classes");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.SectorId).HasColumnName("sector_id");
            builder.Property(p => p.FundId).HasColumnName("fund_id");
            builder.HasOne(m => m.Sector).WithMany(o => o.LoanProducts).HasForeignKey(mp => mp.SectorId);
            builder.HasOne(m => m.Fund).WithMany(o => o.LoanProducts).HasForeignKey(mp => mp.FundId);
            builder.HasOne(m => m.ProductType).WithMany(o => o.LoanProducts).HasForeignKey(mp => mp.ProductTypeId);
            builder.HasOne(m => m.ChargeGroup).WithMany(o => o.LoanProducts).HasForeignKey(mp => mp.ChargeGroupId);
            builder.HasMany(m => m.ChargedItems).WithOne(o => o.LoanProduct).HasForeignKey(mp => mp.LoanProductId);
            builder.HasMany(m => m.TaxableItems).WithOne(o => o.LoanProduct).HasForeignKey(mp => mp.LoanProductId);
            builder.HasMany(m => m.ProductParams).WithOne(o => o.LoanProduct).HasForeignKey(mp => mp.LoanProductId);
            builder.HasMany(m => m.AdjustedRates).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.FeesPaymentLevels).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.IndividualLoans).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.BusinessLoans).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.GroupLoans).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.AgingClasses).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.LoanAmountClasses).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.Penalties).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
        }
    }
}
