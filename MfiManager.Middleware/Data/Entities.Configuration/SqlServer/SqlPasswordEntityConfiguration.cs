using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlPasswordEntityConfiguration {

        public static void Configure(EntityTypeBuilder<Password> builder) {
            builder.ToTable("TBL_MFI_SYSTEMUSER_PWD");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.PasswordHash).HasColumnName("pwd_hash").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.ExpiryDate).HasColumnName("expiry_date").IsRequired(false);
            builder.Property(p => p.SystemUserId).HasColumnName("user_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.SystemUser).WithMany(e => e.Passwords).HasForeignKey(e => e.SystemUserId);
        }
    }
    
}
