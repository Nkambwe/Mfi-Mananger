using MfiManager.Middleware.Data.Entities.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlIssuerAuthorityEntityConfiguration {

        public static void Configure(EntityTypeBuilder<IssuerAuthority> builder) {
            builder.ToTable("TBL_MFI_IDENTIFICATION_ISSUER");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("authority_code").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.AuthorityName).HasColumnName("authority_name").HasColumnType("NVARCHAR(MAX)");
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(p => p.Identifications).WithOne(e => e.IssuerAuthority).HasForeignKey(e => e.IssuerAuthorityId);
        }
    }
}
