using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.PostgreSql {

    public class PsqlLoginAttemptEntityConfiguration {

        public static void Configure(EntityTypeBuilder<LoginAttempt> builder) {
            builder.ToTable("Loginattempts", "public");
            builder.HasKey(a => a.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("nextval('loginattempt_seq')").HasColumnName("id");
            builder.Property(a => a.UserId).HasColumnName("user_id");
            builder.Property(a => a.IpAddress).HasColumnName("ip_address").HasColumnType("VARCHAR(20)").IsRequired();
            builder.Property(a => a.LoginDate).HasColumnName("login_date").IsRequired();
            builder.Property(a => a.Successful).HasColumnName("is_successful");

            builder.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            builder.Property(e => e.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(e => e.CreatedBy).HasColumnName("created_by").HasColumnType("VARCHAR(10)").IsRequired();
            builder.Property(e => e.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasColumnType("VARCHAR(10)").IsRequired(false);

            builder.HasOne(a => a.User).WithMany(c => c.Attempts).HasForeignKey(b => b.UserId);
        }

    }

}
