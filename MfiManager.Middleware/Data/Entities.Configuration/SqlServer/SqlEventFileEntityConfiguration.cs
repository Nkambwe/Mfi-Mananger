using MfiManager.Middleware.Data.Entities.Operations.Insurance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlEventFileEntityConfiguration {

        public static void Configure(EntityTypeBuilder<EventFile> builder) {
            builder.ToTable("TBL_MFI_INSURANCE_EVENT_FILE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Series).HasColumnName("event_series").HasColumnType("NVARCHAR(10)");
            builder.Property(p => p.FileUrl).HasColumnName("file_url").HasColumnType("NVARCHAR(MAX)");
            builder.Property(p => p.FileType).HasColumnName("file_type");
            builder.Property(p => p.EventId).HasColumnName("event_id").IsRequired();
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Event).WithMany(e => e.Files).HasForeignKey(e => e.EventId);
        }
    }
}
