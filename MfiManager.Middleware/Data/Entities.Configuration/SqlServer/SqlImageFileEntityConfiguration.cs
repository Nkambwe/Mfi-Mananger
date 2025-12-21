using MfiManager.Middleware.Data.Entities.Customer.Files;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlImageFileEntityConfiguration {

        public static void Configure(EntityTypeBuilder<ImageFile> builder) {
            builder.ToTable("TBL_MFI_IMAGE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.FileUrl).HasColumnName("file_url").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.FileId).HasColumnName("file_id").IsRequired(false);
            builder.Property(p => p.TitleDeedId).HasColumnName("title_deed_id").IsRequired(false);
            builder.Property(p => p.IdentificationId).HasColumnName("identity_id").IsRequired(false);
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.File).WithMany(e => e.Images).HasForeignKey(e => e.FileId);
            builder.HasOne(p => p.TitleDeed).WithMany(e => e.Images).HasForeignKey(e => e.TitleDeedId);
            builder.HasOne(p => p.Identification).WithMany(e => e.Images).HasForeignKey(e => e.IdentificationId);
        }
    }

}
