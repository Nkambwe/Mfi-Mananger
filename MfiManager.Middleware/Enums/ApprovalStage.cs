using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    /// <summary>
    /// Loan approval stage
    /// </summary>
    public enum ApprovalStage { 
        [Description("First Stage Approval")]
        FirstStage = 1,
        [Description("Second Stage Approval")]
        SecondStage = 2,
        [Description("Third Stage Approval")]
        ThirdStage= 3,
        [Description("Fourth Stage Approval")]
        FourthStage = 4
    }
}
