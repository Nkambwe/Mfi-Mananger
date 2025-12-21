using MfiManager.Middleware.Data.Entities.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlReasonCategoryEntityConfiguration {
        public static void Configure(EntityTypeBuilder<ReasonCategory> builder) {
             builder.ToTable("TBL_MFI_REASON_CATEGORY");
             builder.HasKey(p => p.Id);
             builder.Property(p => p.Id).HasColumnName("id");
             builder.Property(p => p.Code).HasColumnName("caregory_code").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.Series).HasColumnName("series_number").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.CustomSeries).HasColumnName("custom_series").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.Description).HasColumnName("description").HasColumnType("NVARCHAR(250)").IsRequired();
             builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired();
             builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
             builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
             builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
             builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
             builder.HasMany(m => m.Reasons).WithOne(o => o.ReasonCategory).HasForeignKey(mp => mp.ReasonCategoryId);
        }
    }
}
