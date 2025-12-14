using MfiManager.Middleware.Data.Entities.Accounts.Charges;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlChargeEntityConfiguration {
        public static void Configure(EntityTypeBuilder<Charge> builder) {
            builder.ToTable("TBL_MFI_CHARGE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("charge_code").HasColumnType("NVARCHAR(10)");
            builder.Property(p => p.Series).HasColumnName("charge_series").HasColumnType("NVARCHAR(10)");
            builder.Property(p => p.ChargeName).HasColumnName("charge_name").HasColumnType("NVARCHAR(200)");
            builder.Property(p => p.IsRated).HasColumnName("is_rated");
            builder.Property(p => p.ApplisToRegistration).HasColumnName("applies_reg");
            builder.Property(p => p.AppliesToSavings).HasColumnName("applies_saving");
            builder.Property(p => p.AppliesToTimeDeposits).HasColumnName("applies_timedeposit");
            builder.Property(p => p.AppliesToShares).HasColumnName("applies_shares");
            builder.Property(p => p.AppliesToInsurance).HasColumnName("applies_insuarance");
            builder.Property(p => p.AppliesToLoans).HasColumnName("applies_loans");
            builder.Property(p => p.LastCount).HasColumnName("last_count");
            builder.Property(p => p.Notes).HasColumnName("charge_note").HasColumnType("NVARCHAR(MAX)");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(m => m.ChargeItems).WithOne(o => o.Charge).HasForeignKey(mp => mp.ChargeId);
        }
    }
}
