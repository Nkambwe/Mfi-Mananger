using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {

    public class SqlUserEntityConfiguration {

        public static void Configure(EntityTypeBuilder<SystemUser> builder) {
            builder.ToTable("TBL_MFI_USER");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnName("id");
            builder.Property(u => u.Username).HasColumnName("username").HasColumnType("NVARCHAR(100)").IsRequired();
            builder.Property(u => u.FirstName).HasColumnName("first_name").HasColumnType("NVARCHAR(100)").IsRequired();
            builder.Property(u => u.OtherName).HasColumnName("other_name").HasColumnType("NVARCHAR(100)").IsRequired(false);
            builder.Property(u => u.LastName).HasColumnName("last_name").HasColumnType("NVARCHAR(100)").IsRequired();
            builder.Property(u => u.PFNumber).HasColumnName("pf_number").HasColumnType("NVARCHAR(20)").IsRequired();
            builder.Property(u => u.EmailAddress).HasColumnName("email_address").HasColumnType("NVARCHAR(150)").IsRequired();
            builder.Property(u => u.PhoneNumber).HasColumnName("phone_number").HasColumnType("NVARCHAR(25)").IsRequired();
            builder.Property(u => u.PasswordHash).HasColumnName("password_hash").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(u => u.BranchCode).HasColumnName("branch_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(u => u.DepartmentUnit).HasColumnName("unit_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(u => u.IsApproved).HasColumnName("is_approved");
            builder.Property(u => u.IsVerified).HasColumnName("is_verified");
            builder.Property(u => u.IsActive).HasColumnName("is_active");
            builder.Property(u => u.IsLocked).HasColumnName("is_locked");
            builder.Property(u => u.IsLoggedIn).HasColumnName("is_logged_in");
            builder.Property(u => u.DepartmentId).HasColumnName("department_id");
            builder.Property(u => u.RoleId).HasColumnName("role_id");
            builder.Property(u => u.IsDeleted).HasColumnName("is_deleted");
            builder.Property(u => u.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(u => u.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(u => u.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(u => u.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(u => u.Department).WithMany(d => d.Users).HasForeignKey(u => u.DepartmentId);
            builder.HasOne(u => u.Role).WithMany(r => r.Users).HasForeignKey(u => u.RoleId);
            builder.HasMany(u => u.QuickActions).WithOne(q => q.User).HasForeignKey(q => q.UserId);
            builder.HasMany(u => u.ActivityLogs).WithOne(a => a.User).HasForeignKey(a => a.UserId);
        }
    }
}
