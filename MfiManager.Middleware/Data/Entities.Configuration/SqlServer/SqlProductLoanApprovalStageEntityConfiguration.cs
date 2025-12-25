using MfiManager.Middleware.Data.Entities.Operations.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlProductLoanApprovalStageEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<ProductLoanApprovalStage> builder) {
            builder.ToTable("TBL_MFI_LOAN_PRODUCT_APPROVALSTAGE");
            builder.HasKey(bc => new { bc.ProductId, bc.ApprovalStageId });
            builder.Property(bc => bc.ProductId).HasColumnName("product_id").IsRequired();
            builder.Property(bc => bc.ApprovalStageId).HasColumnName("approval_stage_id").IsRequired();
            builder.HasOne(bc => bc.ApprovalStage).WithMany(p => p.Products).HasForeignKey(bc => bc.ApprovalStageId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Product).WithMany(g => g.ApprovalStages).HasForeignKey(bc => bc.ProductId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
