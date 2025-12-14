using MfiManager.Middleware.Data.Entities.Operations.Trade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlPurchaseOrderClassificationEntityConfiguration {

        public static void Configure(EntityTypeBuilder<PurchaseOrderClassification> builder) {
            builder.ToTable("TBL_MFI_PURCHASE_ORDER_CLASSIFICATION");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("class_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.Name).HasColumnName("class_name").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(p => p.Notes).HasColumnName("class_notes").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(m => m.PurchaseOrderDefaults).WithOne(o => o.OrderClassification).HasForeignKey(mp => mp.OrderClassificationId);
        }
    }
}
