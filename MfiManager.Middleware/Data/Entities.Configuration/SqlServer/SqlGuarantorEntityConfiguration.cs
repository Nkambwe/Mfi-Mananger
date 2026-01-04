using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {

    public class SqlGuarantorEntityConfiguration {

        public static void Configure(EntityTypeBuilder<Guarantor> builder) {
            builder.ToTable("TBL_MFI_GUARANTOR");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("guarantor_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.Reference).HasColumnName("member_ref").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.FirstName).HasColumnName("first_name").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(p => p.MiddleName).HasColumnName("middle_name").HasColumnType("NVARCHAR(200)").IsRequired(false);
            builder.Property(p => p.LastName).HasColumnName("last_name").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(p => p.Gender).HasColumnName("gender").IsRequired();
            builder.Property(p => p.Signature).HasColumnName("signature").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.Photo).HasColumnName("photo").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsClient).HasColumnName("is_client");
            builder.Property(p => p.PermanentAddress).HasColumnName("physical_address").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.Telephone).HasColumnName("phone_number").HasColumnType("NVARCHAR(20)").IsRequired(false);
            builder.Property(p => p.Mobile).HasColumnName("mobile_tel").HasColumnType("NVARCHAR(20)").IsRequired(false);
            builder.Property(p => p.Email).HasColumnName("email_address").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.City).HasColumnName("city").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.Town).HasColumnName("town").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.ProfessionId).HasColumnName("profession_id").IsRequired(false);
            builder.Property(p => p.NationalityId).HasColumnName("nationality_id").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.TitleId).HasColumnName("title_id").IsRequired(false);
            builder.Property(p => p.VillageId).HasColumnName("village_id").IsRequired(false);
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.HasOne(p => p.Title).WithMany(e => e.Guarantors).HasForeignKey(e => e.TitleId);
            builder.HasOne(p => p.Village).WithMany(e => e.Guarantors).HasForeignKey(e => e.VillageId);
            builder.HasOne(p => p.Profession).WithMany(e => e.Guarantors).HasForeignKey(e => e.ProfessionId);
            builder.HasOne(p => p.Nationality).WithMany(e => e.Guarantors).HasForeignKey(e => e.NationalityId);
            builder.HasMany(p => p.Languages).WithOne(e => e.Guarantor).HasForeignKey(e => e.GuarantorId);
            builder.HasMany(p => p.Collateral).WithOne(e => e.Guarantor).HasForeignKey(e => e.GuarantorId);
            builder.HasMany(p => p.Overdrafts).WithOne(e => e.Guarantor).HasForeignKey(e => e.OverdraftId);
            builder.HasMany(p => p.IndividualLoanGuarantors).WithOne(e => e.Guarantor).HasForeignKey(e => e.GuarantorId);
            builder.HasMany(p => p.Languages).WithOne(e => e.Guarantor).HasForeignKey(e => e.GuarantorId);
        }
    }

}
