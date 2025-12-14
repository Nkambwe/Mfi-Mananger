using MfiManager.Middleware.Data.Entities.Accounts.Charges;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlChargeStageEntityConfiguration {
        public static void Configure(EntityTypeBuilder<ChargeStage> builder) {
            builder.ToTable("TBL_MFI_CHARGE_STAGE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ProductId).HasColumnName("product_id").IsRequired();
            builder.Property(p => p.BeforeApplication).HasColumnName("before_application");
            builder.Property(p => p.BeforeApproval).HasColumnName("before_approval");
            builder.Property(p => p.AfterApproval).HasColumnName("after_approval");
            builder.Property(p => p.AtDisbursement).HasColumnName("at_disbursement");
            builder.Property(p => p.ChargeItemId).HasColumnName("charge_item_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.ChargeItem).WithMany(o => o.ChargeStages).HasForeignKey(mp => mp.ChargeItemId);
            builder.HasOne(m => m.Product).WithMany(o => o.ChargeStages).HasForeignKey(mp => mp.ProductId);
        }
    }
}
