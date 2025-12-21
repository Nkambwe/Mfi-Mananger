using MfiManager.Middleware.Data.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlCustomerApprovalEntityConfiguration {

        public static void Configure(EntityTypeBuilder<CustomerApproval> builder) {
            builder.ToTable("TBL_MFI_CUSTOMER_APPROVAL");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ApprovalStatus).HasColumnName("approve_status").HasColumnType("NVARCHAR(20)").IsRequired();
            builder.Property(p => p.ApprovedOn).HasColumnName("approved_on");
            builder.Property(p => p.ApprovedBy).HasColumnName("approved_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.Comments).HasColumnName("comments").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.PersonId).HasColumnName("personal_id").IsRequired(false);
            builder.Property(p => p.GroupId).HasColumnName("group_id").IsRequired(false);
            builder.Property(p => p.BusinessId).HasColumnName("business_id").IsRequired(false);
            builder.Property(p => p.MemberId).HasColumnName("member_id").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Individual).WithMany(e => e.CustomerApprovals).HasForeignKey(e => e.Individual);
            builder.HasOne(p => p.Group).WithMany(e => e.CustomerApprovals).HasForeignKey(e => e.GroupId);
            builder.HasOne(p => p.Business).WithMany(e => e.CustomerApprovals).HasForeignKey(e => e.BusinessId);
            builder.HasOne(p => p.Member).WithMany(e => e.CustomerApprovals).HasForeignKey(e => e.MemberId);
        }
    }

}
