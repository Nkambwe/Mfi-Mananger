using MfiManager.Middleware.Data.Entities.Operations.Reasons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlReasonCategoryEntityConfiguration {
        public static void Configure(EntityTypeBuilder<ReasonGroup> builder) {
             builder.ToTable("TBL_MFI_REASON_GROUP");
             builder.HasKey(p => p.Id);
             builder.Property(p => p.Id).HasColumnName("id");
             builder.Property(p => p.SerieIdentifier).HasColumnName("series_id").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.SeriePrefix).HasColumnName("series_prefix").HasColumnType("NVARCHAR(10)").IsRequired(false);
             builder.Property(p => p.LastSeries).HasColumnName("last_series");
             builder.Property(p => p.Description).HasColumnName("description").HasColumnType("NVARCHAR(250)").IsRequired();
             builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired();
             builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
             builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
             builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
             builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
             builder.HasMany(m => m.Reasons).WithOne(o => o.ReasonGroup).HasForeignKey(mp => mp.ReasonGroupId);
        }
    }
}
