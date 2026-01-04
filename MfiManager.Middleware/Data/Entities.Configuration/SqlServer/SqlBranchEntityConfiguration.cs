using MfiManager.Middleware.Data.Entities.Operations.Branches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {

    public class SqlBranchEntityConfiguration {
        public static void Configure(EntityTypeBuilder<Branch> builder) {
            builder.ToTable("TBL_MFI_BRANCH");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("id");
            builder.Property(b => b.CompanyId).HasColumnName("company_id");
            builder.Property(b => b.BranchCode).HasColumnName("branch_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(b => b.BranchName).HasColumnName("branch_name").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(b => b.Address).HasColumnName("address").HasColumnType("NVARCHAR(200)").IsRequired(false);
            builder.Property(b => b.EmailAddress).HasColumnName("email_address").HasColumnType("NVARCHAR(250)").IsRequired(false);
            builder.Property(b => b.PostalAddress).HasColumnName("postal_address").HasColumnType("NVARCHAR(250)").IsRequired(false);
            builder.Property(b => b.IsDeleted).HasColumnName("is_deleted");
            builder.Property(b => b.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(b => b.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(b => b.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(b => b.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(b => b.AccountsChartId).HasColumnName("accounts_chart_id");
            builder.HasOne(b => b.Company).WithMany(c => c.Branches).HasForeignKey(b => b.CompanyId);
            builder.HasMany(mp => mp.Holidays).WithOne(h => h.Branch).HasForeignKey(h => h.BranchId);
            builder.HasMany(mp => mp.SeriesNumbers).WithOne(s => s.Branch).HasForeignKey(s => s.BranchId);
            builder.HasMany(mp => mp.RecurringItems).WithOne(r => r.Branch).HasForeignKey(r => r.BranchId);
            builder.HasMany(mp => mp.Entities).WithOne(e => e.Branch).HasForeignKey(e => e.BranchId);
            builder.HasMany(mp => mp.CostCenters).WithOne(c => c.Branch).HasForeignKey(c => c.BranchId);
            builder.HasMany(mp => mp.LedgerAccounts).WithOne(l => l.Branch).HasForeignKey(l => l.BranchId);
            builder.HasMany(mp => mp.Departments).WithOne(d => d.Branch).HasForeignKey(d => d.BranchId);
            builder.HasMany(mp => mp.References).WithOne(r => r.Branch).HasForeignKey(r => r.BranchId);
            builder.HasMany(mp => mp.BranchRevenueCenters).WithOne(r => r.Branch).HasForeignKey(r => r.BranchId);
            builder.HasMany(mp => mp.LabelFormats).WithOne(f => f.Branch).HasForeignKey(f => f.BranchId);
            builder.HasMany(mp => mp.RevolvingFunds).WithOne(f => f.Branch).HasForeignKey(f => f.BranchId);
        }
    }

}
