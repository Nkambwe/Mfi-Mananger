using MfiManager.Middleware.Data.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlUnLockedCustomerEntityConfiguration {

        public static void Configure(EntityTypeBuilder<UnLockedCustomer> builder) {
            builder.ToTable("TBL_MFI_CUSTOMER_UNLOCKED");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.UnlockedBy).HasColumnName("unlocked_by").HasColumnType("NVARCHAR(10)");
            builder.Property(p => p.UnlockedOn).HasColumnName("unlocked_on");
            builder.Property(p => p.ReasonId).HasColumnName("reason_id");
            builder.Property(p => p.PersonId).HasColumnName("person_id").IsRequired(false);
            builder.Property(p => p.MemberId).HasColumnName("member_id").IsRequired(false);
            builder.Property(p => p.GroupId).HasColumnName("group_id").IsRequired(false);
            builder.Property(p => p.BusinessId).HasColumnName("business_id").IsRequired(false);
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Reason).WithMany(e => e.UnLockedCustomers).HasForeignKey(e => e.ReasonId);
            builder.HasOne(p => p.Individual).WithMany(e => e.UnLockedCustomers).HasForeignKey(e => e.PersonId);
            builder.HasOne(p => p.Member).WithMany(e => e.UnLockedCustomers).HasForeignKey(e => e.MemberId);
            builder.HasOne(p => p.Business).WithMany(e => e.UnLockedCustomers).HasForeignKey(e => e.BusinessId);
            builder.HasOne(p => p.Group).WithMany(e => e.UnLockedCustomers).HasForeignKey(e => e.GroupId);
        }
    }
}
