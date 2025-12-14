using MfiManager.Middleware.Data.Entities.Accounts.Charges;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlChargeItemChargeEntityConfiguration {

        public static void Configure(EntityTypeBuilder<ChargeItemCharge> builder) {
            builder.ToTable("TBL_MFI_CHARGEITEM_CHARGE");
            builder.HasKey(bc => new { bc.ChargeItemId, bc.ChargeId });
            builder.Property(bc => bc.ChargeItemId).HasColumnName("charge_item_id").IsRequired();
            builder.Property(bc => bc.ChargeId).HasColumnName("charge_id").IsRequired();
            builder.HasOne(bc => bc.ChargeItem).WithMany(p => p.Charges).HasForeignKey(bc => bc.ChargeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Charge).WithMany(g => g.ChargeItems).HasForeignKey(bc => bc.ChargeItemId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
