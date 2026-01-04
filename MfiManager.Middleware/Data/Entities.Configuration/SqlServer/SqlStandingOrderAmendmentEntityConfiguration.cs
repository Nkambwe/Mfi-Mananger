using MfiManager.Middleware.Data.Entities.Operations.Saving;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlStandingOrderAmendmentEntityConfiguration {

        public static void Configure(EntityTypeBuilder<StandingOrderAmendment> builder) {
            builder.ToTable("TBL_MFI_SAVING_ORDER_AMENDMENT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.AmendDate).HasColumnName("amendment_date");
            builder.Property(p => p.Current).HasColumnName("is_current");
            builder.Property(p => p.Frequency).HasColumnName("new_freq");
            builder.Property(p => p.CustomFrequency).HasColumnName("new_cust_freq");
            builder.Property(p => p.FrequencyType).HasColumnName("new_inter_type");
            builder.Property(p => p.StartDate).HasColumnName("new_start_date");
            builder.Property(p => p.StartAmount).HasColumnName("new_start_amount").HasPrecision(9,2);
            builder.Property(p => p.Beneficiary).HasColumnName("new_beneficiary").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.ReferenceNumber).HasColumnName("new_ref_number").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.FrequencyAmount).HasColumnName("new_freq_amount").HasPrecision(9,2);
            builder.Property(p => p.Charge).HasColumnName("new_charge").HasPrecision(9,2);
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.ExecutionDate).HasColumnName("new_execution_date").IsRequired(false);
            builder.Property(p => p.EndDate).HasColumnName("new_end_date").IsRequired(false);
            builder.Property(p => p.SavingAccountId).HasColumnName("new_saving_account_id");
            builder.Property(p => p.LedgerAccountId).HasColumnName("new_saving_ledger_id").IsRequired(false);
            builder.Property(p => p.StandingOrderId).HasColumnName("standingOrder_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.StandingOrder).WithMany(e => e.OrderAmendments).HasForeignKey(e => e.StandingOrderId);
        }
    }

}
