using MfiManager.Middleware.Data.Entities.Operations.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlInsuranceProductEntityConfiguration {
        public static void Configure(EntityTypeBuilder<InsuranceProduct> builder) {
            builder.ToTable("TBL_MFI_INSURANCE_PRODUCT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ProductId).HasColumnName("product_id");
            builder.Property(p => p.CoverageId).HasColumnName("coverage_id");
            builder.Property(p => p.Period).HasColumnName("period");
            builder.Property(p => p.AllowPremiumModification).HasColumnName("allow_premium_modif");
            builder.Property(p => p.ChargeMonthlyPremium).HasColumnName("should_charge_premium");
            builder.Property(p => p.PercentageAdministrativeAmount).HasColumnName("percentage_admin_amount").HasPrecision(9,2);
            builder.Property(p => p.AdministrativeCostLedgerAccount).HasColumnName("admin_cost_ledger").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.PercentageClaimAmount).HasColumnName("percentage_claim_amount").HasPrecision(9,2);
            builder.Property(p => p.ClaimLedgerAccount).HasColumnName("claim_ledger").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.MinimumInsuredPersons).HasColumnName("min_number");
            builder.Property(p => p.MaximumInsuredPersons).HasColumnName("max_number");
            builder.Property(p => p.MinimumInsuredAge).HasColumnName("min_age");
            builder.Property(p => p.MaximumInsuredAge).HasColumnName("max_age");
            builder.Property(p => p.Fees).HasColumnName("fees").HasPrecision(9,2);
            builder.Property(p => p.FeesLedgerAccount).HasColumnName("fees_ledger").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Product).WithMany(o => o.InsuranceProducts).HasForeignKey(mp => mp.ProductId);
            builder.HasOne(m => m.Coverage).WithMany(o => o.InsuranceProducts).HasForeignKey(mp => mp.CoverageId);
            builder.HasMany(m => m.Policies).WithOne(o => o.InsuranceProduct).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.Providers).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
        }
    }

}
