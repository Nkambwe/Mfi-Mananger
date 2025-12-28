using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlWittenOffLoanEntityConfiguration {

        public static void Configure(EntityTypeBuilder<WittenOffLoan> builder) {
            builder.ToTable("TBL_MFI_LOAN_WRITTENOFF");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.WriteOffOn).HasColumnName("writeoff_date");
            builder.Property(p => p.WrittenoffAmount).HasColumnName("writtenoff_amount");
            builder.Property(p => p.WittenOffBy).HasColumnName("writtenoff_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.ReasonId).HasColumnName("reason_id");
            builder.Property(p => p.IndividualLoanId).HasColumnName("individual_lnr_id").IsRequired(false);
            builder.Property(p => p.BusinessLoanId).HasColumnName("business_lnr_id").IsRequired(false);
            builder.Property(p => p.GroupLoanId).HasColumnName("group_lnr_id").IsRequired(false);
            builder.HasOne(p => p.Reason).WithMany(e => e.Loans).HasForeignKey(e => e.ReasonId);
            builder.HasOne(p => p.IndividualLoan).WithMany(e => e.WittenOffLoans).HasForeignKey(e => e.IndividualLoanId);
            builder.HasOne(p => p.BusinessLoan).WithMany(e => e.WittenOffLoans).HasForeignKey(e => e.BusinessLoanId);
            builder.HasOne(p => p.GroupLoan).WithMany(e => e.WittenOffLoans).HasForeignKey(e => e.GroupLoanId);
        }
    }
}
