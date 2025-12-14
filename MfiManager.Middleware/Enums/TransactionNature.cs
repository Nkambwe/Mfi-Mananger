using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    public enum TransactionNature {
        Unspecified = 0,
        Receipt = 1,
        Payment = 2,
        Donation = 3,
        Drawing = 4,
        Discount = 5,
        Loss = 6,
        Gain = 7,
        [Description("Standing Order")]
        StandingOrder = 8
    }
}
