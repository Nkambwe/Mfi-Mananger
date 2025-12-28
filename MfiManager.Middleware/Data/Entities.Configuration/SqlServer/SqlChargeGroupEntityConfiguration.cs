using MfiManager.Middleware.Data.Entities.Accounts.Charges;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlChargeGroupEntityConfiguration {

        public static void Configure(EntityTypeBuilder<ChargeGroup> builder) {
            builder.ToTable("TBL_MFI_CHARGE_GROUP");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.SerieIdentifier).HasColumnName("serie_id").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.SeriePrefix).HasColumnName("serie_prefix").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.GroupName).HasColumnName("group_name").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(p => p.LastSeries).HasColumnName("last_series");
            builder.Property(p => p.Notes).HasColumnName("group_notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(m => m.TimedepositProducts).WithOne(o => o.ChargeGroup).HasForeignKey(mp => mp.ChargeGroupId);
            builder.HasMany(m => m.InsuranceProducts).WithOne(o => o.ChargeGroup).HasForeignKey(mp => mp.ChargeGroupId);
            builder.HasMany(m => m.ShareProducts).WithOne(o => o.ChargeGroup).HasForeignKey(mp => mp.ChargeGroupId);
            builder.HasMany(m => m.SavingProducts).WithOne(o => o.ChargeGroup).HasForeignKey(mp => mp.ChargeGroupId);
            builder.HasMany(m => m.LoanProducts).WithOne(o => o.ChargeGroup).HasForeignKey(mp => mp.ChargeGroupId);
            builder.HasMany(m => m.ChargeGroupItems).WithOne(o => o.ChargeGroup).HasForeignKey(mp => mp.ChargeGroupId);
        }
    }
}
