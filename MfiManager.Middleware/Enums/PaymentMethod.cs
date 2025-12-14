using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    public enum PaymentMethod {
        None = 0,
        Cash = 1,
        Cheque = 2,
        Card = 3,
        Electronic = 4,
        /// <summary>
        /// Postdated cheque
        /// </summary>
        [Description("Post-dated")]
        Postdated = 5,
        Refund = 6
    }
}
