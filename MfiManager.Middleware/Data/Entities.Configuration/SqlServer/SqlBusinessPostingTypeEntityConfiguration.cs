using MfiManager.Middleware.Data.Entities.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlBusinessPostingTypeEntityConfiguration {
        public static void Configure(EntityTypeBuilder<BusinessPostingType> builder) {
             builder.ToTable("TBL_MFI_BUSINESS_POSTING_TYPE");
             builder.HasKey(p => p.Id);
             builder.Property(p => p.Id).HasColumnName("id");
             builder.Property(p => p.Code).HasColumnName("posting_code").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.SeriesIdentifier).HasColumnName("series_identifier").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.CustomSeries).HasColumnName("custom_series");
             builder.Property(p => p.Description).HasColumnName("description").HasColumnType("NVARCHAR(250)").IsRequired();
             builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired();
             builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
             builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
             builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
             builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
             builder.HasMany(m => m.BusinessItems).WithOne(o => o.BusinessPostingType).HasForeignKey(mp => mp.BusinessPostingId);
             
        }
    }
}
