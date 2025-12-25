using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    public enum OfficerPositionCode {
        [Description("LF")]
        Officer = 1,
        [Description("CF")]
        CreditOfficer = 2,
        [Description("CA")]
        CreditAnalyst = 3,
        [Description("SA")]
        SeniorCreditAnalyst = 4,
        [Description("BA")]
        BranchManager = 5,
        [Description("DO")]
        DisbursementOfficer = 6
    }
}
