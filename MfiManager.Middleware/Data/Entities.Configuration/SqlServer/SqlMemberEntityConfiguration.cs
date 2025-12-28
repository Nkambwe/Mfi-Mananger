using MfiManager.Middleware.Data.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {

    public class SqlMemberEntityConfiguration {

        public static void Configure(EntityTypeBuilder<Member> builder) {
            builder.ToTable("TBL_MFI_MEMBER");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.TitleId).HasColumnName("title_id").IsRequired(false);
            builder.Property(p => p.ClientCode).HasColumnName("client_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.MemberNumber).HasColumnName("member_number").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.Statistic).HasColumnName("statistic_number").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.Reference).HasColumnName("member_ref").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.RegisteredOn).HasColumnName("reg_date");
            builder.Property(p => p.FirstName).HasColumnName("last_name").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(p => p.MiddleName).HasColumnName("middle_name").HasColumnType("NVARCHAR(200)").IsRequired(false);
            builder.Property(p => p.LastName).HasColumnName("last_name").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(p => p.Gender).HasColumnName("gender").IsRequired();
            builder.Property(p => p.VillageId).HasColumnName("village_id").IsRequired(false);
            builder.Property(p => p.Signature).HasColumnName("signature").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.Photo).HasColumnName("photo").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.ClientType).HasColumnName("client_type");
            builder.Property(p => p.HoldShares).HasColumnName("has_shares");
            builder.Property(p => p.MaritalStatus).HasColumnName("marital_status");
            builder.Property(p => p.SpouseName).HasColumnName("spouse_name").HasColumnType("NVARCHAR(200)").IsRequired(false);
            builder.Property(p => p.Children).HasColumnName("num_children");
            builder.Property(p => p.Dependents).HasColumnName("num_dependents");
            builder.Property(p => p.Mother).HasColumnName("mother_name").HasColumnType("NVARCHAR(200)").IsRequired(false);
            builder.Property(p => p.Father).HasColumnName("father_name").HasColumnType("NVARCHAR(200)").IsRequired(false);
            builder.Property(p => p.DateOfBirth).HasColumnName("birth_date").IsRequired(false);
            builder.Property(p => p.BirthPlace).HasColumnName("birth_place").HasColumnType("NVARCHAR(180)").IsRequired(false);
            builder.Property(p => p.RightThumbPrint).HasColumnName("right_thumb").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.LeftThumbPrint).HasColumnName("left_thumb").HasColumnType("NVARCHAR(180)").IsRequired(false);
            builder.Property(p => p.Literate).HasColumnName("is_literate");
            builder.Property(p => p.PermanentAddress).HasColumnName("physical_address").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.MailAddress).HasColumnName("mail_address").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.PrimaryLine).HasColumnName("primary_tel").HasColumnType("NVARCHAR(20)").IsRequired(false);
            builder.Property(p => p.SecondaryLine).HasColumnName("secondary_tel").HasColumnType("NVARCHAR(20)").IsRequired(false);
            builder.Property(p => p.Mobile).HasColumnName("mobile_tel").HasColumnType("NVARCHAR(20)").IsRequired(false);
            builder.Property(p => p.Fax).HasColumnName("fax_num").HasColumnType("NVARCHAR(20)").IsRequired(false);
            builder.Property(p => p.Email).HasColumnName("email_address").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.City).HasColumnName("city").HasColumnType("NVARCHAR(200)").IsRequired(false);
            builder.Property(p => p.Town).HasColumnName("town").HasColumnType("NVARCHAR(200)").IsRequired(false);
            builder.Property(p => p.JoinedOn).HasColumnName("joined_on").IsRequired();
            builder.Property(p => p.ExitedOn).HasColumnName("exited_on").IsRequired(false);
            builder.Property(p => p.WhatsApp).HasColumnName("whatsapp").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.Facebook).HasColumnName("facebook").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.Instagram).HasColumnName("instagram").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.Twitter).HasColumnName("twitter").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.Filter1Id).HasColumnName("filter1_id").IsRequired(false);
            builder.Property(p => p.Filter2Id).HasColumnName("filter2_id").IsRequired(false);
            builder.Property(p => p.Filter3Id).HasColumnName("filter3_id").IsRequired(false);
            builder.Property(p => p.MemberFilter1).HasColumnName("filter2_id").IsRequired(false);
            builder.Property(p => p.MemberFilter2).HasColumnName("filter3_id").IsRequired(false);
            builder.Property(p => p.EducationId).HasColumnName("education_id").IsRequired(false);
            builder.Property(p => p.NationalityId).HasColumnName("nationality_id").IsRequired(false);
            builder.Property(p => p.GroupId).HasColumnName("group_id");
            builder.Property(p => p.ProfessionId).HasColumnName("profession_id").IsRequired(false);
            builder.Property(p => p.Approved).HasColumnName("is_approved");
            builder.Property(p => p.ApprovedBy).HasColumnName("approved_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.ApprovedOn).HasColumnName("approved_on").IsRequired(false);
            builder.Property(p => p.Exited).HasColumnName("is_exited");
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Title).WithMany(e => e.Members).HasForeignKey(e => e.TitleId);
            builder.HasOne(p => p.Village).WithMany(e => e.Members).HasForeignKey(e => e.VillageId);
            builder.HasOne(p => p.Group).WithMany(e => e.Members).HasForeignKey(e => e.GroupId);
            builder.HasMany(p => p.IncomeHistories).WithOne(e => e.Member).HasForeignKey(e => e.MemberId);
            builder.HasMany(p => p.Languages).WithOne(e => e.Member).HasForeignKey(e => e.MemberId);
            builder.HasMany(p => p.Positions).WithOne(e => e.Member).HasForeignKey(e => e.MemberId);
            builder.HasMany(p => p.MemberTransfers).WithOne(e => e.Member).HasForeignKey(e => e.MemberId);
            builder.HasMany(p => p.CustomerApprovals).WithOne(e => e.Member).HasForeignKey(e => e.MemberId);
            builder.HasMany(p => p.ShareAccounts).WithOne(e => e.Member).HasForeignKey(e => e.MemberId);
            builder.HasMany(p => p.TimedepositAccounts).WithOne(e => e.Member).HasForeignKey(e => e.MemberId);
            builder.HasMany(p => p.Policies).WithOne(e => e.Member).HasForeignKey(e => e.MemberId);
            builder.HasMany(p => p.Rejects).WithOne(e => e.Member).HasForeignKey(e => e.MemberId);
        }

    }
}
