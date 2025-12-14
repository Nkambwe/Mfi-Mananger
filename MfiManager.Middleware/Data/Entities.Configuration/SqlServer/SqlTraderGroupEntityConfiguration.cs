using MfiManager.Middleware.Data.Entities.Accounts.Taxes;
using MfiManager.Middleware.Data.Entities.Operations.Trade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlTraderGroupEntityConfiguration {

        public static void Configure(EntityTypeBuilder<TraderGroup> builder) {
            builder.ToTable("TBL_MFI_VENDOR_CATEGORY");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("code").HasColumnType("NVARCHAR(10)");
            builder.Property(p => p.Group).HasColumnName("category_name").HasColumnType("NVARCHAR(200)");
            builder.Property(p => p.Notes).HasColumnName("group_notes").HasColumnType("NVARCHAR(MAX)");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(p => p.Traders).WithOne(t => t.Group).HasForeignKey(t => t.GroupId);
        }
    }

}
