using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    /// <summary>
    /// Loan approval stage
    /// </summary>
    public enum ApprovalStage { 
        [Description("First Stage")]
        FirstStage = 1,
        [Description("Second Stage")]
        SecondStage = 2,
        [Description("Third Stage")]
        ThirdStage= 3,
        [Description("Fourth Stage")]
        FourthStage = 4
    }
}
