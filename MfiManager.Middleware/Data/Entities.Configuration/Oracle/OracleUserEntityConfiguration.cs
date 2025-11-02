using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.Oracle {

    public class OracleUserEntityConfiguration {

        public static void Configure(EntityTypeBuilder<SystemUser> builder) {
            builder.ToTable("SYSTEMUSERS");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("USER_SEQ.NEXTVAL");
            builder.Property(e => e.Username).HasMaxLength(200).IsRequired();
            builder.Property(e => e.FirstName).HasColumnType("CLOB").IsRequired();
            builder.Property(e => e.OtherName).HasColumnType("CLOB").IsRequired();
            builder.Property(e => e.LastName).HasColumnType("CLOB").IsRequired();
            builder.Property(e => e.PFNumber).HasColumnType("CLOB").IsRequired();
            builder.Property(e => e.EmailAddress).HasColumnType("CLOB").IsRequired();
            builder.Property(e => e.PhoneNumber).HasColumnType("CLOB").IsRequired();
            builder.Property(e => e.PasswordHash).HasColumnType("CLOB").IsRequired();
            builder.Property(e => e.BranchCode).IsRequired();
            builder.Property(e => e.DepartmentUnit).IsRequired();
            builder.Property(e => e.RoleId).IsRequired();
            builder.Property(e => e.DepartmentId).IsRequired();
            builder.Property(e => e.IsApproved).IsRequired(false);
            builder.Property(e => e.IsVerified).IsRequired(false);
            builder.Property(e => e.IsDeleted).IsRequired();
            builder.Property(e => e.IsActive).IsRequired();
            builder.Property(e => e.IsLocked).IsRequired();
            builder.Property(e => e.IsLoggedIn).IsRequired();

            builder.ConfigureAuditFields();
        }
    }

}
