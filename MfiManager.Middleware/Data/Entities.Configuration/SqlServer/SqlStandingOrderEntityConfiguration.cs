using MfiManager.Middleware.Data.Entities.Operations.Saving;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlStandingOrderEntityConfiguration {

        public static void Configure(EntityTypeBuilder<StandingOrder> builder) {
            builder.ToTable("TBL_MFI_SAVING_ORDER");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.OrderNumber).HasColumnName("order_number").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.OrderDate).HasColumnName("order_date");
            builder.Property(p => p.Frequency).HasColumnName("freq");
            builder.Property(p => p.CustomFrequency).HasColumnName("cust_freq");
            builder.Property(p => p.IntervalType).HasColumnName("inter_type");
            builder.Property(p => p.Beneficiary).HasColumnName("beneficiary").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.ReferenceNumber).HasColumnName("ref_number").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.StartDate).HasColumnName("start_date");
            builder.Property(p => p.StartAmount).HasColumnName("start_amount").HasPrecision(9,2);
            builder.Property(p => p.FrequencyAmount).HasColumnName("freq_amount").HasPrecision(9,2);
            builder.Property(p => p.Charge).HasColumnName("charge").HasPrecision(9,2);
            builder.Property(p => p.ExecutionDate).HasColumnName("exec_date").IsRequired(false);
            builder.Property(p => p.EndDate).HasColumnName("end_date").IsRequired(false);
            builder.Property(p => p.PayAtNotice).HasColumnName("pay_at_notice");
            builder.Property(p => p.Cancelled).HasColumnName("is_cancelled");
            builder.Property(p => p.CancelledOn).HasColumnName("cancelled_date").IsRequired(false);
            builder.Property(p => p.CancelNotes).HasColumnName("cancel_notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.SavingAccountId).HasColumnName("saving_account_id");
            builder.Property(p => p.LedgerAccountId).HasColumnName("saving_ledger_id").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.SavingAccount).WithMany(e => e.StandingOrders).HasForeignKey(e => e.SavingAccountId);
            builder.HasOne(p => p.LedgerAccount).WithMany(e => e.StandingOrders).HasForeignKey(e => e.LedgerAccountId);
            builder.HasMany(p => p.Modifications).WithOne(e => e.StandingOrder).HasForeignKey(e => e.StandingOrderId);
            builder.HasMany(p => p.OrderAmendments).WithOne(e => e.StandingOrder).HasForeignKey(e => e.StandingOrderId);
        }
    }

}
