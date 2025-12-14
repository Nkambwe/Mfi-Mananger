using MfiManager.Middleware.Data.Entities.Operations.Shares;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlShareValueEntityConfiguration {

        public static void Configure(EntityTypeBuilder<ShareValue> builder) {
            builder.ToTable("TBL_MFI_SHARE_VALUE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ProductId).HasColumnName("product_id");
            builder.Property(p => p.Current).HasColumnName("is_current");
            builder.Property(p => p.PerValue).HasColumnName("per_value").HasPrecision(9,2);
            builder.Property(p => p.AddedOn).HasColumnName("added_on");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Product).WithMany(o => o.ShareValues).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.ShareTransactions).WithOne(o => o.ShareValue).HasForeignKey(mp => mp.ShareValueId);
        }
    }

}
