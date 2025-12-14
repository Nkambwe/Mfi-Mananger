using MfiManager.Middleware.Data.Entities.Accounts.Charges;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlChargeGroupItemEntityConfiguration {

        public static void Configure(EntityTypeBuilder<ChargeGroupItem> builder) {
            builder.ToTable("TBL_MFI_CHARGE_GROUP_ITEM");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("item_code").HasColumnType("NVARCHAR(10)");
            builder.Property(p => p.ChargeName).HasColumnName("item_name").HasColumnType("NVARCHAR(200)");
            builder.Property(p => p.IsRated).HasColumnName("is_percentage");
            builder.Property(p => p.Rate).HasColumnName("per_rate").HasPrecision(19,2);
            builder.Property(p => p.FlatAmount).HasColumnName("flat_amount").HasPrecision(19,2);
            builder.Property(p => p.Notes).HasColumnName("charge_note").HasColumnType("NVARCHAR(MAX)");
            builder.Property(p => p.ChargeGroupId).HasColumnName("charge_group_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.ChargeGroup).WithMany(o => o.ChargeGroupItems).HasForeignKey(mp => mp.ChargeGroupId);
        }
    }
}
