using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlLoginAttemptEntityConfiguration {
        public static void Configure(EntityTypeBuilder<LoginAttempt> builder) {
            builder.ToTable("TBL_MFI_LOGIN_ATTEMPT");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("id");
            builder.Property(a => a.UserId).HasColumnName("user_id");
            builder.Property(a => a.IpAddress).HasColumnName("ip_address").HasColumnType("NVARCHAR(80)").IsRequired();
            builder.Property(a => a.LoginDate).HasColumnName("login_date").IsRequired();
            builder.Property(a => a.Successful).HasColumnName("is_successful");
            builder.Property(a => a.IsDeleted).HasColumnName("is_deleted");
            builder.Property(a => a.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(a => a.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(a => a.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(a => a.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);

            builder.HasOne(a => a.User).WithMany(u => u.Attempts).HasForeignKey(a => a.UserId);
        }
    }

}
