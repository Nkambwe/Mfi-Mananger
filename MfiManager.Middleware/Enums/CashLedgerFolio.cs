using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    public enum CashLedgerFolio {
        [Description("Unknown Cash method")]
        Unspecified = 0,
        [Description("Cash Payment")]
        Receipt = 1,
        [Description("Mobile Payment")]
        Payment = 2,
        [Description("Internal Transfer")]
        TransferIn = 3,
        [Description("External Transfer")]
        TransferOut = 4,
        [Description("Opening Balance")]
        OpeningBalance = 5,
        [Description("Closing Balance")]
        ClosingBalance = 6
    }
}
