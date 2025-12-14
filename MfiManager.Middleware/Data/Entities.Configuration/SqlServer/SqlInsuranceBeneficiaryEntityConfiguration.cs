using MfiManager.Middleware.Data.Entities.Operations.Insurance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlInsuranceBeneficiaryEntityConfiguration {

        public static void Configure(EntityTypeBuilder<InsuranceBeneficiary> builder) {
            builder.ToTable("TBL_MFI_INSURANCE_BENEFICIARY");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("beneficiary_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.Name).HasColumnName("beneficiary_name").HasColumnType("NVARCHAR(250)").IsRequired();
            builder.Property(p => p.IsClient).HasColumnName("is_client");
            builder.Property(p => p.ClientCode).HasColumnName("client_code").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.DateOfBirth).HasColumnName("born_on");
            builder.Property(p => p.Gender).HasColumnName("gender");
            builder.Property(p => p.Address).HasColumnName("physical_address").HasColumnType("NVARCHAR(30)").IsRequired(false);
            builder.Property(p => p.Telephone).HasColumnName("telephone").HasColumnType("NVARCHAR(20)").IsRequired(false);
            builder.Property(p => p.Mobile).HasColumnName("mobile").HasColumnType("NVARCHAR(20)").IsRequired(false);
            builder.Property(p => p.RelationshipToHolder).HasColumnName("relationships").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(p => p.ExcludeFromPolicy).HasColumnName("exclude_policy");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(m => m.Policies).WithOne(o => o.Beneficiary).HasForeignKey(mp => mp.BeneficiaryId);
        }
    }

}
