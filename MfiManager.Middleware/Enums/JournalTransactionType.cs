using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    public enum JournalTransactionType {
        All = 0,
        [Description("Payment")]
        Payment = 1,
        [Description("Receipt")]
        Receipt = 2,
        [Description("Payment Transfer")]
        PaymentTransfer = 3,
        [Description("Receipt Transfer")]
        ReceiptTransfer = 4,
        [Description("Payment By Cheque")]
        ChequePayment = 5,
        [Description("Receipt By Cheque")]
        ChequeReceipt = 6,
        [Description("Inter-branch Transfer")]
        InterBranchTransfer = 7,
        [Description("Inter-branch Payment")]
        InterBranchPayment = 8,
        [Description("Inter-branch Receipt")]
        InterBranchReceipt = 9
    }
}
