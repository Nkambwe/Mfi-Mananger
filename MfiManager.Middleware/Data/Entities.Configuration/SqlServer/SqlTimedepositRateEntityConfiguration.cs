using MfiManager.Middleware.Data.Entities.Operations.Timedeposit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlTimedepositRateEntityConfiguration {

        public static void Configure(EntityTypeBuilder<TimedepositRate> builder) {
            builder.ToTable("TBL_MFI_TIMEDEPOSIT_RATE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.PercentageRate).HasColumnName("rate");
            builder.Property(p => p.Started).HasColumnName("start_date");
            builder.Property(p => p.Ended).HasColumnName("end_date").IsRequired(false);
            builder.Property(p => p.ProductId).HasColumnName("product_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Product).WithMany(o => o.InterestRates).HasForeignKey(mp => mp.ProductId);
        }
    }

}
