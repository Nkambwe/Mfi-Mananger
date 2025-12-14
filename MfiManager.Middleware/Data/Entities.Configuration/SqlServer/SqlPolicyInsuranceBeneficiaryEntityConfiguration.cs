using MfiManager.Middleware.Data.Entities.Operations.Insurance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlPolicyInsuranceBeneficiaryEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<PolicyInsuranceBeneficiary> builder) {
            builder.ToTable("TBL_MFI_INSURANCE_POLICY_BENEFICIARY");
            builder.HasKey(bc => new { bc.BeneficiaryId, bc.PolicyId });
            builder.Property(bc => bc.BeneficiaryId).HasColumnName("beneficiary_id").IsRequired();
            builder.Property(bc => bc.PolicyId).HasColumnName("policy_id").IsRequired();
            builder.HasOne(bc => bc.Beneficiary).WithMany(p => p.Policies).HasForeignKey(bc => bc.BeneficiaryId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Policy).WithMany(g => g.Beneficiaries).HasForeignKey(bc => bc.PolicyId).OnDelete(DeleteBehavior.Cascade);
        }

    }

}
