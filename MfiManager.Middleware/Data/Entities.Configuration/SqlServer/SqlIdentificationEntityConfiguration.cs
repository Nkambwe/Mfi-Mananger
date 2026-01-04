using MfiManager.Middleware.Data.Entities.Customers.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlIdentificationEntityConfiguration {

        public static void Configure(EntityTypeBuilder<Identification> builder) {
            builder.ToTable("TBL_MFI_IDENTIFICATION");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.FileUrl).HasColumnName("file_url").HasColumnType("NVARCHAR(MAX)");
            builder.Property(p => p.IssuedOn).HasColumnName("issued_on");
            builder.Property(p => p.ExpiresOn).HasColumnName("expires_on").IsRequired(false);
            builder.Property(p => p.IdentityTypeId).HasColumnName("type_id");
            builder.Property(p => p.IssuerAuthorityId).HasColumnName("issuer_id");
            builder.Property(p => p.PersonId).HasColumnName("person_id").IsRequired(false);
            builder.Property(p => p.MemberId).HasColumnName("member_id").IsRequired(false);
            builder.Property(p => p.SignatoryId).HasColumnName("signatory_id").IsRequired(false);
            builder.Property(p => p.SavingPartnerId).HasColumnName("partner_id").IsRequired(false);
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.IdentityType).WithMany(e => e.Identifications).HasForeignKey(e => e.IdentityTypeId);
            builder.HasOne(p => p.IssuerAuthority).WithMany(e => e.Identifications).HasForeignKey(e => e.IssuerAuthorityId);
            builder.HasOne(p => p.Person).WithMany(e => e.Identifications).HasForeignKey(e => e.PersonId);
            builder.HasOne(p => p.Member).WithMany(e => e.Identifications).HasForeignKey(e => e.MemberId);
            builder.HasOne(p => p.Signatory).WithMany(e => e.Identifications).HasForeignKey(e => e.SignatoryId);
            builder.HasOne(p => p.SavingPartner).WithMany(e => e.Identifications).HasForeignKey(e => e.SavingPartnerId);
            builder.HasMany(p => p.Images).WithOne(e => e.Identification).HasForeignKey(e => e.IdentificationId);
        }
    }

}
