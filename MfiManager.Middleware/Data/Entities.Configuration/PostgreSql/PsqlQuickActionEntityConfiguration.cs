  using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.PostgreSql {

    public class PsqlQuickActionEntityConfiguration {

        public static void Configure(EntityTypeBuilder<UserQuickAction> builder) {
            builder.ToTable("quickactions", "public");
            builder.HasKey(q => q.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("nextval('quickaction_seq')").HasColumnName("id");
            builder.Property(q => q.UserId).HasColumnName("user_id");
            builder.Property(q => q.Label).HasColumnName("action_label").HasColumnType("TEXT").IsRequired();
            builder.Property(q => q.IconClass).HasColumnName("branch_name").HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(q => q.Controller).HasColumnName("controller").HasColumnType("VARCHAR(200)").IsRequired();
            builder.Property(q => q.Action).HasColumnName("action_details").HasColumnType("TEXT").IsRequired();
            builder.Property(q => q.Area).HasColumnName("action_area").HasColumnType("VARCHAR(200)").IsRequired();
            builder.Property(q => q.CssClass).HasColumnName("css_class").HasColumnType("VARCHAR(200)").IsRequired();

            builder.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            builder.Property(e => e.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(e => e.CreatedBy).HasColumnName("created_by").HasColumnType("VARCHAR(10)").IsRequired();
            builder.Property(e => e.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasColumnType("VARCHAR(10)").IsRequired(false);

            builder.HasOne(q => q.User).WithMany(c => c.QuickActions).HasForeignKey(q => q.UserId);
        }

    }


}
