using MfiManager.Middleware.Data.Entities.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlHolidayEntityConfiguration {

        public static void Configure(EntityTypeBuilder<Holiday> builder) {
            builder.ToTable("TBL_MFI_HOLIDAY");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Month).HasColumnName("month_no");
            builder.Property(p => p.Day).HasColumnName("no_day");
            builder.Property(p => p.IsOccasional).HasColumnName("is_occas");
            builder.Property(p => p.Exclude).HasColumnName("is_excluded");
            builder.Property(p => p.BranchId).HasColumnName("branch_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Branch).WithMany(e => e.Holidays).HasForeignKey(e => e.BranchId);
        }
    }

}
