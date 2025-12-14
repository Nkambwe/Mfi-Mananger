using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    public enum SavingInterestCalculation {
        [Description("Daily")]
        Daily = 1,
        [Description("Monthly")]
        Monthly = 2,
        [Description("Two Monthly")]
        TwoMonths = 3,
        [Description("Three Monthly")]
        ThreeMonths = 4,
        [Description("Quarterly")]
        FourMonths = 5
    }
}
