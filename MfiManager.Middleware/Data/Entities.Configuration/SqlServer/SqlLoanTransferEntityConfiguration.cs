using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlLoanTransferEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<LoanTransfer> builder) {
            builder.ToTable("TBL_MFI_LOAN_TRANSFER");
            builder.HasKey(p => p.Id );
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.FormerOfficer).HasColumnName("former_officer").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.CurrentOfficer).HasColumnName("current_officer").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.TranferDate).HasColumnName("tranfer_date");
            builder.Property(p => p.IndividualLoanId).HasColumnName("individual_lnr_id").IsRequired(false);
            builder.Property(p => p.BusinessLoanId).HasColumnName("business_lnr_id").IsRequired(false);
            builder.Property(p => p.GroupLoanId).HasColumnName("group_lnr_id").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(bc => bc.IndividualLoan).WithMany(p => p.Transfers).HasForeignKey(bc => bc.IndividualLoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.BusinessLoan).WithMany(p => p.Transfers).HasForeignKey(bc => bc.BusinessLoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.GroupLoan).WithMany(p => p.Transfers).HasForeignKey(bc => bc.GroupLoanId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
