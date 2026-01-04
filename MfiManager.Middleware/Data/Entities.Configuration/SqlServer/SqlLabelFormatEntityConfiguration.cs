using MfiManager.Middleware.Data.Entities.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlLabelFormatEntityConfiguration {

        public static void Configure(EntityTypeBuilder<LabelFormat> builder) {
            builder.ToTable("TBL_MFI_LABEL_FORMAT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Series).HasColumnName("series_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.Expression).HasColumnName("lbl_expression").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.FormatType).HasColumnName("format_type");
            builder.Property(p => p.BranchId).HasColumnName("branch_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Branch).WithMany(e => e.LabelFormats).HasForeignKey(e => e.BranchId);
        }
    }

}
