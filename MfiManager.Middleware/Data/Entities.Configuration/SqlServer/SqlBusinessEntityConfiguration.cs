using MfiManager.Middleware.Data.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {

    public class SqlBusinessEntityConfiguration {

        public static void Configure(EntityTypeBuilder<Business> builder) {
            builder.ToTable("TBL_MFI_BUSINESS");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ClientCode).HasColumnName("group_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.Statistic).HasColumnName("statistic_number").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.Reference).HasColumnName("member_ref").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.LegalName).HasColumnName("business_name").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.RegisteredOn).HasColumnName("reg_date");
            builder.Property(p => p.ClientType).HasColumnName("client_type");
            builder.Property(p => p.HoldShares).HasColumnName("has_shares");
            builder.Property(p => p.PermanentAddress).HasColumnName("physical_address").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.MailAddress).HasColumnName("mail_address").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.PrimaryLine).HasColumnName("primary_tel").HasColumnType("NVARCHAR(20)").IsRequired(false);
            builder.Property(p => p.SecondaryLine).HasColumnName("secondary_tel").HasColumnType("NVARCHAR(20)").IsRequired(false);
            builder.Property(p => p.Mobile).HasColumnName("mobile_tel").HasColumnType("NVARCHAR(20)").IsRequired(false);
            builder.Property(p => p.Fax).HasColumnName("fax_num").HasColumnType("NVARCHAR(20)").IsRequired(false);
            builder.Property(p => p.Email).HasColumnName("email_address").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.City).HasColumnName("city").HasColumnType("NVARCHAR(200)").IsRequired(false);
            builder.Property(p => p.Town).HasColumnName("town").HasColumnType("NVARCHAR(200)").IsRequired(false);
            builder.Property(p => p.WhatsApp).HasColumnName("whatsapp").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.Facebook).HasColumnName("facebook").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.Instagram).HasColumnName("instagram").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.Twitter).HasColumnName("twitter").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.Filter1Id).HasColumnName("filter_1_id").IsRequired(false);
            builder.Property(p => p.Filter2Id).HasColumnName("filter_2_id").IsRequired(false);
            builder.Property(p => p.Filter3Id).HasColumnName("filter_3_id").IsRequired(false);
            builder.Property(p => p.BusinessFilter1Id).HasColumnName("business_filter_1_id").IsRequired(false);
            builder.Property(p => p.BusinessFilter2Id).HasColumnName("business_filter_2_id").IsRequired(false);
            builder.Property(p => p.Approved).HasColumnName("is_approved");
            builder.Property(p => p.ApprovedBy).HasColumnName("approved_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.ApprovedOn).HasColumnName("approved_on").IsRequired(false);
            builder.Property(p => p.Exited).HasColumnName("is_exited");
            builder.Property(p => p.BranchId).HasColumnName("branch_id");
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Branch).WithMany(e => e.Businesses).HasForeignKey(e => e.BranchId);
            builder.HasOne(p => p.Village).WithMany(e => e.Businesses).HasForeignKey(e => e.VillageId);
            builder.HasOne(p => p.ClientFilter1).WithMany(e => e.Businesses).HasForeignKey(e => e.Filter1Id);
            builder.HasOne(p => p.ClientFilter2).WithMany(e => e.Businesses).HasForeignKey(e => e.Filter2Id);
            builder.HasOne(p => p.ClientFilter3).WithMany(e => e.Businesses).HasForeignKey(e => e.Filter3Id);
            builder.HasOne(p => p.BusinessFilter1).WithMany(e => e.Businesses).HasForeignKey(e => e.BusinessFilter1Id);
            builder.HasOne(p => p.BusinessFilter2).WithMany(e => e.Businesses).HasForeignKey(e => e.BusinessFilter2Id);
            builder.HasMany(p => p.Approvals).WithOne(e => e.Business).HasForeignKey(e => e.BusinessId);
            builder.HasMany(p => p.Signatories).WithOne(e => e.Business).HasForeignKey(e => e.BusinessId);
        }
    }
}
