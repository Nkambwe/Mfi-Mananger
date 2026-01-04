using MfiManager.Middleware.Data.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlEmploymentHistoryEntityConfiguration {

        public static void Configure(EntityTypeBuilder<EmploymentHistory> builder) {
            builder.ToTable("TBL_MFI_CUSTOMER_EMPLOYMENT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Employer).HasColumnName("employer_name").HasColumnType("NVARCHAR(MAX)");
            builder.Property(p => p.Position).HasColumnName("position_held").HasColumnType("NVARCHAR(200)");
            builder.Property(p => p.Earning).HasColumnName("earning").HasPrecision(9,2);
            builder.Property(p => p.FromDate).HasColumnName("from_date");
            builder.Property(p => p.WorkHere).HasColumnName("work_here");
            builder.Property(p => p.ToDate).HasColumnName("to_date").IsRequired(false);
            builder.Property(p => p.PersonId).HasColumnName("person_id").IsRequired(false);
            builder.Property(p => p.MemberId).HasColumnName("member_id").IsRequired(false);
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Individual).WithMany(e => e.EmploymentHistories).HasForeignKey(e => e.PersonId);
            builder.HasOne(p => p.Member).WithMany(e => e.EmploymentHistories).HasForeignKey(e => e.MemberId);
        }
    }
}
