using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.PostgreSql {

    public class PsqlBranchEntityConfiguration {
        public static void Configure(EntityTypeBuilder<Branch> builder) {
            builder.ToTable("branches", "public");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                   .HasDefaultValueSql("nextval('branch_seq')")
                   .HasColumnName("id");

            builder.Property(b => b.CompanyId).HasColumnName("company_id").IsRequired();
            builder.Property(b => b.BranchCode).HasColumnName("branch_code").HasColumnType("VARCHAR(10)").IsRequired();
            builder.Property(b => b.BranchName).HasColumnName("branch_name").HasColumnType("VARCHAR(150)").IsRequired();
            builder.Property(b => b.Address).HasColumnName("address").HasColumnType("VARCHAR(200)").IsRequired(false);
            builder.Property(b => b.EmailAddress).HasColumnName("email_address").HasColumnType("VARCHAR(100)").IsRequired(false);
            builder.Property(b => b.PostalAddress).HasColumnName("postal_address").HasColumnType("VARCHAR(100)").IsRequired(false);

            builder.Property(b => b.IsDeleted).HasColumnName("is_deleted");
            builder.Property(b => b.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(b => b.CreatedBy).HasColumnName("created_by").HasColumnType("VARCHAR(10)").IsRequired();
            builder.Property(b => b.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(b => b.ModifiedBy).HasColumnName("modified_by").HasColumnType("VARCHAR(10)").IsRequired(false);

            builder.HasOne(b => b.Company).WithMany(c => c.Branches).HasForeignKey(b => b.CompanyId);
            builder.HasMany(b => b.SystemConfigurations).WithOne(s => s.Branch).HasForeignKey(s => s.BranchId);
        }
    }


}
