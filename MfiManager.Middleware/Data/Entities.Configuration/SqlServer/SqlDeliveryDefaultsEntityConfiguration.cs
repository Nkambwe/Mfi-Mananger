using MfiManager.Middleware.Data.Entities.Operations.Trade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlDeliveryDefaultsEntityConfiguration {

        public static void Configure(EntityTypeBuilder<DeliveryDefaults> builder) {
            builder.ToTable("TBL_MFI_DELIVERY_DEFAULTS");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Receiver).HasColumnName("reciever_name").HasColumnType("NVARCHAR(250)").IsRequired(false);
            builder.Property(p => p.ReferenceGroup).HasColumnName("ref_group").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.ReferenceValue).HasColumnName("ref_value").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.DeliveryAddress).HasColumnName("del_address").HasColumnType("NVARCHAR(250)").IsRequired(false);
            builder.Property(p => p.Currency).HasColumnName("currency").HasColumnType("NVARCHAR(3)").IsRequired(false);
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.TraderId).HasColumnName("trader_id").IsRequired(false);
            builder.Property(p => p.SupplierId).HasColumnName("supplier_id").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Trader).WithMany(e => e.DeliveryDefaults).HasForeignKey(e => e.TraderId);
            builder.HasOne(p => p.Supplier).WithMany(e => e.DeliveryDefaults).HasForeignKey(e => e.SupplierId);
        }
    }

}
