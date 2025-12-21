using MfiManager.Middleware.Data.Entities.Accounts.Cashflows;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlBankEntityConfiguration {
        public static void Configure(EntityTypeBuilder<Bank> builder) {
             builder.ToTable("TBL_MFI_BANK");
             builder.HasKey(p => p.Id);
             builder.Property(p => p.Id).HasColumnName("id");
             builder.Property(p => p.Code).HasColumnName("bank_code").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.Name).HasColumnName("bank_name").HasColumnType("NVARCHAR(250)").IsRequired();
             builder.Property(p => p.Contact).HasColumnName("contact").HasColumnType("NVARCHAR(250)").IsRequired(false);
             builder.Property(p => p.Telephone).HasColumnName("telephone").HasColumnType("NVARCHAR(25)").IsRequired(false);
             builder.Property(p => p.Email).HasColumnName("email").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
             builder.Property(p => p.Fax).HasColumnName("fax").HasColumnType("NVARCHAR(25)").IsRequired(false);
             builder.Property(p => p.IbanId).HasColumnName("iban").IsRequired(false);
             builder.Property(p => p.SwiftId).HasColumnName("swift").IsRequired(false);
             builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
             builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
             builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
             builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
             builder.HasOne(m => m.Iban).WithMany(o => o.Banks).HasForeignKey(mp => mp.IbanId);
             builder.HasOne(m => m.Swift).WithMany(o => o.Banks).HasForeignKey(mp => mp.SwiftId);
             builder.HasMany(m => m.Branches).WithOne(o => o.Bank).HasForeignKey(mp => mp.BankId);
        }
    }
}
