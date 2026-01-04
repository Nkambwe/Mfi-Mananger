using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.PostgreSql {

    public class PsqlUserEntityConfiguration {
         public static void Configure(EntityTypeBuilder<SystemUser> builder) {
            builder.ToTable("systemusers", "public");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("nextval('Systemuser_seq')").HasColumnName("id");
            builder.Property(e => e.Username).HasColumnName("username").HasColumnType("TEXT").IsRequired();
            builder.Property(e => e.FirstName).HasColumnName("first_name").HasColumnType("TEXT").IsRequired();
            builder.Property(e => e.OtherName).HasColumnName("other_name").HasColumnType("TEXT").IsRequired();
            builder.Property(e => e.LastName).HasColumnName("last_name").HasColumnType("TEXT").IsRequired();
            builder.Property(e => e.PFNumber).HasColumnName("pf_number").HasColumnType("VARCHAR(10)").IsRequired();
            builder.Property(e => e.EmailAddress).HasColumnName("emal_address").HasColumnType("TEXT").IsRequired();
            builder.Property(e => e.PhoneNumber).HasColumnName("phone_number").HasColumnType("VARCHAR(25)").IsRequired();
            builder.Property(e => e.PasswordHash).HasColumnName("password_hash").HasColumnType("TEXT").IsRequired();
            builder.Property(e => e.BranchCode).HasColumnName("branch_code").HasColumnType("VARCHAR(10)").IsRequired();
            builder.Property(e => e.DepartmentUnit).HasColumnName("unit_code").HasColumnType("VARCHAR(10)").IsRequired();
            builder.Property(e => e.IsApproved).HasColumnName("is_approved");
            builder.Property(e => e.IsVerified).HasColumnName("is_verified");
            builder.Property(e => e.IsActive).HasColumnName("is_active");
            builder.Property(e => e.IsLocked).HasColumnName("is_locked");
            builder.Property(e => e.IsLoggedIn).HasColumnName("is_loggedin");
            builder.Property(e => e.DepartmentId).HasColumnName("dept_id");
            builder.Property(e => e.RoleId).HasColumnName("role_id");
            builder.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            builder.Property(e => e.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(e => e.CreatedBy).HasColumnName("created_by").HasColumnType("VARCHAR(10)").IsRequired();
            builder.Property(e => e.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(e => e.ModifiedBy).HasColumnName("modified_by").HasColumnType("VARCHAR(10)").IsRequired(false);
            builder.HasOne(u => u.Department).WithMany(d => d.SystemUsers).HasForeignKey(u => u.DepartmentId);
            builder.HasOne(u => u.Role).WithMany(r => r.Users).HasForeignKey(u => u.RoleId);
            builder.HasMany(u => u.QuickActions).WithOne(q => q.User).HasForeignKey(a => a.UserId);
            builder.HasMany(u => u.Prefferences).WithOne(p => p.SystemUser).HasForeignKey(a => a.SystemUserId);
            builder.HasMany(u => u.ActivityLogs).WithOne(a => a.User).HasForeignKey(a => a.UserId);
         }
    }

}
