using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlRevolvingFundEntityConfiguration {

        public static void Configure(EntityTypeBuilder<RevolvingFund> builder) {
            builder.ToTable("TBL_MFI_REVOLVING_FUND");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("sector_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.Name).HasColumnName("sector_name").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.Started).HasColumnName("started_on").IsRequired(false);
            builder.Property(p => p.Ended).HasColumnName("ended_on").IsRequired(false);
            builder.Property(p => p.SavingsBased).HasColumnName("is_saving_based");
            builder.Property(p => p.LoanablePercentage).HasColumnName("loanable_percentage").HasPrecision(9,2);
            builder.Property(p => p.CurrencyId).HasColumnName("currency_id");
            builder.Property(p => p.DonorId).HasColumnName("donor_id").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Currency).WithMany(o => o.RevolvingFunds).HasForeignKey(mp => mp.CurrencyId);
            builder.HasOne(m => m.Donor).WithMany(o => o.RevolvingFunds).HasForeignKey(mp => mp.DonorId);
            builder.HasMany(m => m.LoanProducts).WithOne(o => o.Fund).HasForeignKey(mp => mp.FundId);
            builder.HasMany(m => m.Branches).WithOne(o => o.RevolvingFund).HasForeignKey(mp => mp.FundId);
            builder.HasMany(m => m.Loans).WithOne(o => o.RevolvingFund).HasForeignKey(mp => mp.FundId);
        }
    }

}
