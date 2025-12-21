using MfiManager.Middleware.Data.Entities.Customers.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlSignatoryEntityConfiguration {

        public static void Configure(EntityTypeBuilder<Signatory> builder) {
            builder.ToTable("TBL_MFI_BUSINESS_SIGNATORY");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("signatory_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.Name).HasColumnName("signatory_name").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.Photo).HasColumnName("photo").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.Signature).HasColumnName("signature").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.Telephone).HasColumnName("phone_number").HasColumnType("NVARCHAR(25)").IsRequired(false);
            builder.Property(p => p.Mobile).HasColumnName("mobile_number").HasColumnType("NVARCHAR(25)").IsRequired(false);
            builder.Property(p => p.Email).HasColumnName("email").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.Position).HasColumnName("position").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.Position).HasColumnName("position").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.Suspended).HasColumnName("suspended");
            builder.Property(p => p.CanSignAlone).HasColumnName("can_sign_alone");
            builder.Property(p => p.PassCode).HasColumnName("pass_code_hash").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.BusinessId).HasColumnName("business_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Business).WithMany(o => o.Signatories).HasForeignKey(mp => mp.BusinessId);
        }
    }
}
