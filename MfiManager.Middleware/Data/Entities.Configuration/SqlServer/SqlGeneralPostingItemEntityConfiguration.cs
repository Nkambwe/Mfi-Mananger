using MfiManager.Middleware.Data.Entities.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {

    public class SqlGeneralPostingItemEntityConfiguration {
        public static void Configure(EntityTypeBuilder<GeneralPostingItem> builder) {
             builder.ToTable("TBL_MFI_GENERAL_POSTING_ITEM");
             builder.HasKey(p => p.Id);
             builder.Property(p => p.Id).HasColumnName("id");
             builder.Property(p => p.Code).HasColumnName("item_code").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.Series).HasColumnName("series_number").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.Description).HasColumnName("description").HasColumnType("NVARCHAR(250)").IsRequired();
             builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired();
             builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
             builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
             builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
             builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
             builder.HasOne(m => m.GeneralPostingType).WithMany(o => o.GeneralPostingItems).HasForeignKey(mp => mp.GeneralPostingTypeId);
             builder.HasMany(m => m.Journals).WithOne(o => o.GeneralPostingItem).HasForeignKey(mp => mp.GeneralPostingId);
             builder.HasMany(m => m.Vouchers).WithOne(o => o.GeneralPostingItem).HasForeignKey(mp => mp.GeneralPostingId);
        }
    }
}
