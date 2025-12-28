using MfiManager.Middleware.Data.Entities.System.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlSeriesParamEntityConfiguration {
        public static void Configure(EntityTypeBuilder<SeriesParam> builder) {
            builder.ToTable("TBL_MFI_SERIES_CONFIG"); 
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).HasColumnName("id");
            builder.Property(f => f.CompanyId).HasColumnName("company_id");
            builder.Property(f => f.SeriesName).HasColumnName("series_name").HasColumnType("NVARCHAR(250)").IsRequired();
            builder.Property(f => f.LastSerie).HasColumnName("last_series").IsRequired();
            builder.Property(f => f.Starts).HasColumnName("start_series").IsRequired();
            builder.Property(f => f.Ends).HasColumnName("end_series").IsRequired(false);
            builder.Property(f => f.IsDeleted).HasColumnName("is_deleted");
            builder.Property(f => f.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(f => f.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(f => f.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(f => f.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(f => f.Company).WithMany(c => c.SeriesParams).HasForeignKey(f => f.CompanyId);
        }
    }
}
