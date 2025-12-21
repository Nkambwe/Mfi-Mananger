using MfiManager.Middleware.Data.Entities.Operations.Saving;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlSavingPartnerEntityConfiguration {

        public static void Configure(EntityTypeBuilder<SavingPartner> builder) {
            builder.ToTable("TBL_MFI_SAVING_PARTNER");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.PartnerName).HasColumnName("partner_name").HasColumnType("NVARCHAR(MAX)");
            builder.Property(p => p.Signatory).HasColumnName("is_signatory");
            builder.Property(p => p.Email).HasColumnName("email_address").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.Phone).HasColumnName("phone_number").HasColumnType("NVARCHAR(20)").IsRequired(false);
            builder.Property(p => p.OnlySignatory).HasColumnName("can_signe_alone");
            builder.Property(p => p.IsCustomer).HasColumnName("is_customer");
            builder.Property(p => p.PersonId).HasColumnName("person_id").IsRequired(false);
            builder.Property(p => p.MemberId).HasColumnName("member_id").IsRequired(false);
            builder.Property(p => p.SavingAccountId).HasColumnName("saving_acc_id").IsRequired();
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Individual).WithMany(e => e.SavingPartners).HasForeignKey(e => e.PersonId);
            builder.HasOne(p => p.Member).WithMany(e => e.SavingPartners).HasForeignKey(e => e.MemberId);
            builder.HasOne(p => p.SavingAccount).WithMany(e => e.SavingPartners).HasForeignKey(e => e.SavingAccountId);
            builder.HasMany(p => p.Identifications).WithOne(e => e.SavingPartner).HasForeignKey(e => e.SavingPartnerId);
            builder.HasMany(p => p.ImageFiles).WithOne(e => e.SavingPartner).HasForeignKey(e => e.SavingPartnerId);
        }
    }
}
