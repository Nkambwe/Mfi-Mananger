using MfiManager.Middleware.Data.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlAccountsChartEntityConfiguration {

        public static void Configure(EntityTypeBuilder<AccountsChart> builder) {
            builder.ToTable("TBL_MFI_ACCOUNTS_CHART");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ChartName).HasColumnName("chart_name").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(p => p.Description).HasColumnName("description").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.ChartType).HasColumnName("chart_type");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(m => m.Branches).WithOne(o => o.AccountsChart).HasForeignKey(mp => mp.AccountsChartId);
            builder.HasMany(m => m.LedgerAccounts).WithOne(o => o.AccountsChart).HasForeignKey(mp => mp.AccountsChartId);
        }
    }

}
