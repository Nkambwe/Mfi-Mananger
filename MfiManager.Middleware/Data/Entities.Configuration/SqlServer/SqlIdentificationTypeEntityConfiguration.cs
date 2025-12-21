using MfiManager.Middleware.Data.Entities.Customers.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlIdentificationTypeEntityConfiguration {

        public static void Configure(EntityTypeBuilder<IdentificationType> builder) {
            builder.ToTable("TBL_MFI_IDENTIFICATION_TYPE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.TypeName).HasColumnName("type_name").HasColumnType("NVARCHAR(MAX)");
            builder.Property(p => p.Priority).HasColumnName("priority");
            builder.Property(p => p.Required).HasColumnName("is_required");
            builder.Property(p => p.Sufficient).HasColumnName("is_sufficient");
            builder.Property(p => p.LocalFolder).HasColumnName("local_folder").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.FtpFolder).HasColumnName("ftp_folder").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(p => p.Identifications).WithOne(e => e.IdentityType).HasForeignKey(e => e.IdentityTypeId);
        }
    }

}
