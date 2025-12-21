using MfiManager.Middleware.Data.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlSeriesNumberEntityConfiguration {
        public static void Configure(EntityTypeBuilder<SeriesNumber> builder) {
            builder.ToTable("TBL_MFI_SERIES_NUMBER");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Identifier).HasColumnName("series_identifier").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.CustomSeries).HasColumnName("custome_series").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.Code).HasColumnName("series_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.Description).HasColumnName("description").HasColumnType("NVARCHAR(250)").IsRequired();
            builder.Property(p => p.StartNumber).HasColumnName("start_number");
            builder.Property(p => p.EndNumber).HasColumnName("end_number");
            builder.Property(p => p.Starts).HasColumnName("start_period");
            builder.Property(p => p.LastUsed).HasColumnName("end_period");
            builder.Property(p => p.LastNumber).HasColumnName("last_number");
            builder.Property(p => p.Default).HasColumnName("is_default");
            builder.Property(p => p.Manual).HasColumnName("allow_manual");
            builder.Property(p => p.BranchId).HasColumnName("branch_id").IsRequired(false);
            builder.Property(p => p.DocumentTypeId).HasColumnName("document_type_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Branch).WithMany(o => o.SeriesNumbers).HasForeignKey(mp => mp.BranchId);
            builder.HasOne(m => m.DocumentType).WithMany(o => o.SeriesNumbers).HasForeignKey(mp => mp.DocumentTypeId);
        }
    }

}
