using MfiManager.Middleware.Data.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlFinancialYearEntityConfiguration {
        public static void Configure(EntityTypeBuilder<FinancialYear> builder) {
            builder.ToTable("TBL_MFI_FINANCIAL_YEAR");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("year_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.YearName).HasColumnName("year_name").HasColumnType("NVARCHAR(15)").IsRequired();
            builder.Property(p => p.Period).HasColumnName("period").IsRequired();
            builder.Property(p => p.StartDate).HasColumnName("start_date").IsRequired();
            builder.Property(p => p.EndDate).HasColumnName("end_date").IsRequired();
            builder.Property(p => p.Closed).HasColumnName("is_closed");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Branch).WithMany(o => o.FinancialYears).HasForeignKey(mp => mp.BranchId);
            builder.HasMany(m => m.MonthlyClosures).WithOne(o => o.FinancialYear).HasForeignKey(mp => mp.YearId);
        }
    }

}
