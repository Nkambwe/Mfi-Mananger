using MfiManager.Middleware.Data.Entities.Operations.Insurance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlInsuranceClaimEntityConfiguration {
        public static void Configure(EntityTypeBuilder<InsuranceClaim> builder) {
            builder.ToTable("TBL_MFI_INSURANCE_CLAIM");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ClaimNumber).HasColumnName("claimant_number").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.Beneficiary).HasColumnName("beneficiary_name").HasColumnType("NVARCHAR(250)").IsRequired();
            builder.Property(p => p.CoveredByDeduction).HasColumnName("deduction_covered");
            builder.Property(p => p.ReportDate).HasColumnName("report_date");
            builder.Property(p => p.LossDate).HasColumnName("loss_date");
            builder.Property(p => p.Status).HasColumnName("claim_status");
            builder.Property(p => p.Severity).HasColumnName("severity_score");
            builder.Property(p => p.Scale).HasColumnName("severity_scale");
            builder.Property(p => p.PolicyId).HasColumnName("policy_id");
            builder.Property(p => p.ClaimantId).HasColumnName("claimant_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(mp => mp.Policy).WithMany(o => o.Claims).HasForeignKey(mp => mp.ClaimantId);
            builder.HasOne(mp => mp.Claimant).WithMany(o => o.Claims).HasForeignKey(mp => mp.ClaimantId);
        }
    }

}
