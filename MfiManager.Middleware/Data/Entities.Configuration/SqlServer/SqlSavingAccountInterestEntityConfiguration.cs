using MfiManager.Middleware.Data.Entities.Operations.Saving;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlSavingAccountInterestEntityConfiguration {

        public static void Configure(EntityTypeBuilder<SavingAccountInterest> builder) {
            builder.ToTable("TBL_MFI_SAVING_ACCOUNT_INTEREST");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.CalculationDate).HasColumnName("calculated_on").IsRequired();
            builder.Property(p => p.JanuaryInterest).HasColumnName("jan_interest").HasPrecision(9,2);
            builder.Property(p => p.FebruaryInterest).HasColumnName("feb_interest").HasPrecision(9,2);
            builder.Property(p => p.MarchInterest).HasColumnName("mar_interest").HasPrecision(9,2);
            builder.Property(p => p.AprilInterest).HasColumnName("apr_interest").HasPrecision(9,2);
            builder.Property(p => p.MayInterest).HasColumnName("may_interest").HasPrecision(9,2);
            builder.Property(p => p.JuneInterest).HasColumnName("jun_interest").HasPrecision(9,2);
            builder.Property(p => p.JulyInterest).HasColumnName("jul_interest").HasPrecision(9,2);
            builder.Property(p => p.AugustInterest).HasColumnName("aug_interest").HasPrecision(9,2);
            builder.Property(p => p.SeptemberInterest).HasColumnName("sep_interest").HasPrecision(9,2);
            builder.Property(p => p.OctoberInterest).HasColumnName("oct_interest").HasPrecision(9,2);
            builder.Property(p => p.NovemberInterest).HasColumnName("nov_interest").HasPrecision(9,2);
            builder.Property(p => p.DecemberInterest).HasColumnName("dec_interest").HasPrecision(9,2);
            builder.Property(p => p.TotalAmount).HasColumnName("total_amt").HasPrecision(9,2);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.SavingAccount).WithMany(e => e.InterestEarnings).HasForeignKey(e => e.SavingAccountId);
        }
    }

}
