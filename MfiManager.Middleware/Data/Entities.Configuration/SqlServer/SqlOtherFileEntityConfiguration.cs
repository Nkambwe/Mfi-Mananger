using MfiManager.Middleware.Data.Entities.Customer.Files;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlOtherFileEntityConfiguration {

        public static void Configure(EntityTypeBuilder<OtherFile> builder) {
            builder.ToTable("TBL_MFI_FILE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Series).HasColumnName("file_series").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.FileUrl).HasColumnName("file_url").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.FileType).HasColumnName("file_type").IsRequired(false);
            builder.Property(p => p.PersonId).HasColumnName("person_id").IsRequired(false);
            builder.Property(p => p.BusinessId).HasColumnName("business_id").IsRequired(false);
            builder.Property(p => p.GroupId).HasColumnName("group_id").IsRequired(false);
            builder.Property(p => p.MemberId).HasColumnName("member_id").IsRequired(false);
            builder.Property(p => p.SignatoryId).HasColumnName("signatory_id").IsRequired(false);
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Individual).WithMany(e => e.Files).HasForeignKey(e => e.PersonId);
            builder.HasOne(p => p.Business).WithMany(e => e.Files).HasForeignKey(e => e.BusinessId);
            builder.HasOne(p => p.Group).WithMany(e => e.Files).HasForeignKey(e => e.GroupId);
            builder.HasOne(p => p.Member).WithMany(e => e.Files).HasForeignKey(e => e.MemberId);
            builder.HasOne(p => p.Signatory).WithMany(e => e.Files).HasForeignKey(e => e.MemberId);
            builder.HasMany(p => p.Images).WithOne(e => e.File).HasForeignKey(e => e.FileId);
        }
    }

}
