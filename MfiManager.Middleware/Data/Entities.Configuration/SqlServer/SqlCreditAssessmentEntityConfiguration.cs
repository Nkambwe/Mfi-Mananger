using MfiManager.Middleware.Data.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlCreditAssessmentEntityConfiguration {

        public static void Configure(EntityTypeBuilder<CreditAssessment> builder) {
            builder.ToTable("TBL_MFI_CREDIT_ASSESSMENT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IsWorthy).HasColumnName("is_worthy");
            builder.Property(p => p.CreditLimit).HasColumnName("credit_limit").HasPrecision(9,2);
            builder.Property(p => p.MaximumAllowed).HasColumnName("min_allowed").HasPrecision(9,2);
            builder.Property(p => p.AssessedOn).HasColumnName("assessed_on");
            builder.Property(p => p.ConfirmedOn).HasColumnName("confirmed_on").IsRequired(false);
            builder.Property(p => p.ReviewOn).HasColumnName("review_on").IsRequired(false);
            builder.Property(p => p.ConfirmedBy).HasColumnName("confirmed_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.PersonId).HasColumnName("person_id");
            builder.HasOne(m => m.Individual).WithMany(o => o.CreditAssessments).HasForeignKey(mp => mp.PersonId);
        }
    }
}
