using MfiManager.Middleware.Data.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlMonthlyClosureEntityConfiguration {
        public static void Configure(EntityTypeBuilder<MonthlyClosure> builder) {
            builder.ToTable("TBL_MFI_MONTHLY_CLOSURE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Month).HasColumnName("month").IsRequired();
            builder.Property(p => p.StartDate).HasColumnName("start_date").IsRequired();
            builder.Property(p => p.CloseDate).HasColumnName("close_date").IsRequired();
            builder.Property(p => p.YearId).HasColumnName("year_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.FinancialYear).WithMany(o => o.MonthlyClosures).HasForeignKey(mp => mp.YearId);
            builder.HasMany(m => m.GeneralLedgerTransactions).WithOne(o => o.MonthlyClosure).HasForeignKey(mp => mp.MonthlyClosureId);
        }
    }

}
