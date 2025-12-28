using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {

    public class SqlDefferedLoanEntityConfiguration {
        public static void Configure(EntityTypeBuilder<DefferedLoan> builder) {
            builder.ToTable("TBL_MFI_LOAN_DIFFERED");
            builder.HasKey(p => p.Id );
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.StartDate).HasColumnName("start_date").IsRequired();
            builder.Property(p => p.EndDate).HasColumnName("end_date").IsRequired();
            builder.Property(p => p.ApprovedBy).HasColumnName("approved_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.IndividualLoanId).HasColumnName("individual_lnr_id");
            builder.HasOne(bc => bc.IndividualLoan).WithMany(p => p.DefferedLoans).HasForeignKey(bc => bc.IndividualLoanId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(p => p.BusinessLoanId).HasColumnName("business_lnr_id");
            builder.HasOne(bc => bc.BusinessLoan).WithMany(p => p.DefferedLoans).HasForeignKey(bc => bc.BusinessLoanId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(p => p.GroupLoanId).HasColumnName("group_lnr_id");
            builder.HasOne(bc => bc.GroupLoan).WithMany(p => p.DefferedLoans).HasForeignKey(bc => bc.GroupLoanId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(p => p.ReasonId).HasColumnName("reason_id");
            builder.HasOne(bc => bc.Reason).WithMany(p => p.DefferedLoans).HasForeignKey(bc => bc.ReasonId).OnDelete(DeleteBehavior.Cascade);
        }
    }

}
