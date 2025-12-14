using MfiManager.Middleware.Data.Entities.Operations.Insurance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlInsurancePolicyEntityConfiguration {
        public static void Configure(EntityTypeBuilder<Policy> builder) {
            builder.ToTable("TBL_MFI_INSURANCE_POLICY");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.PolicyNumber).HasColumnName("policy_number").HasColumnType("NVARCHAR(20)").IsRequired();
            builder.Property(p => p.EffectiveDate).HasColumnName("effective_date").IsRequired();
            builder.Property(p => p.ExpiryDate).HasColumnName("expiry_date").IsRequired(false);
            builder.Property(p => p.Agent).HasColumnName("insurance_agent").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(p => p.BeneficiariesCount).HasColumnName("beneficiaries_count");
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.ProductId).HasColumnName("product_id");
            builder.Property(p => p.ProviderId).HasColumnName("provider_id");
            builder.Property(p => p.IndividualId).HasColumnName("person_id").IsRequired(false);
            builder.Property(p => p.MemberId).HasColumnName("member_id").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(bc => bc.Individual).WithMany(p => p.Policies).HasForeignKey(bc => bc.IndividualId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Member).WithMany(p => p.Policies).HasForeignKey(bc => bc.MemberId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Provider).WithMany(p => p.Policies).HasForeignKey(bc => bc.ProviderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.InsuranceProduct).WithMany(p => p.Policies).HasForeignKey(bc => bc.ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.PremiumPayments).WithOne(o => o.Policy).HasForeignKey(bc => bc.PolicyId);
            builder.HasMany(bc => bc.Beneficiaries).WithOne(o => o.Policy).HasForeignKey(bc => bc.PolicyId);
            builder.HasMany(bc => bc.Claims).WithOne(o => o.Policy).HasForeignKey(bc => bc.PolicyId);
        }
    }

}
