using MfiManager.Middleware.Data.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlRejectedCustomerEntityConfiguration {

        public static void Configure(EntityTypeBuilder<RejectedCustomer> builder) {
            builder.ToTable("TBL_MFI_CUSTOMER_REJECTED");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.RejectDate).HasColumnName("reject_date");
            builder.Property(p => p.RejectedBy).HasColumnName("rejected_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.ReasonId).HasColumnName("reason_id");
            builder.Property(p => p.MemberId).HasColumnName("member_id");
            builder.Property(p => p.GroupId).HasColumnName("group_id");
            builder.Property(p => p.PersonId).HasColumnName("person_id");
            builder.Property(p => p.BusinessId).HasColumnName("business_id");
            builder.HasOne(p => p.Reason).WithMany(e => e.Customers).HasForeignKey(e => e.ReasonId);
            builder.HasOne(p => p.Member).WithMany(e => e.Rejects).HasForeignKey(e => e.MemberId);
            builder.HasOne(p => p.Group).WithMany(e => e.Rejects).HasForeignKey(e => e.GroupId);
            builder.HasOne(p => p.Individual).WithMany(e => e.Rejects).HasForeignKey(e => e.PersonId);
            builder.HasOne(p => p.Business).WithMany(e => e.Rejects).HasForeignKey(e => e.BusinessId);
        }
    }
}
