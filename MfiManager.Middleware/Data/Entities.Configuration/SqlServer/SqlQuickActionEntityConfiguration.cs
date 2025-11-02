using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlQuickActionEntityConfiguration {
        public static void Configure(EntityTypeBuilder<UserQuickAction> builder) {
            builder.ToTable("TBL_MFI_QUICK_ACTION");
            builder.HasKey(q => q.Id);

            builder.Property(q => q.Id).HasColumnName("id");
            builder.Property(q => q.UserId).HasColumnName("user_id");
            builder.Property(q => q.Label).HasColumnName("action_label").HasColumnType("NVARCHAR(100)").IsRequired();
            builder.Property(q => q.IconClass).HasColumnName("icon_class").HasColumnType("NVARCHAR(80)").IsRequired();
            builder.Property(q => q.Controller).HasColumnName("controller").HasColumnType("NVARCHAR(100)").IsRequired();
            builder.Property(q => q.Action).HasColumnName("action_name").HasColumnType("NVARCHAR(100)").IsRequired();
            builder.Property(q => q.Area).HasColumnName("action_area").HasColumnType("NVARCHAR(100)").IsRequired(false);
            builder.Property(q => q.CssClass).HasColumnName("css_class").HasColumnType("NVARCHAR(100)").IsRequired(false);
            builder.Property(q => q.IsDeleted).HasColumnName("is_deleted");
            builder.Property(q => q.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(q => q.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(q => q.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(q => q.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);

            builder.HasOne(q => q.User).WithMany(u => u.QuickActions).HasForeignKey(q => q.UserId);
        }
    }
}
