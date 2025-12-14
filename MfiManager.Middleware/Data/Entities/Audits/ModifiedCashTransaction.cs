using MfiManager.Middleware.Data.Entities.System;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Audits {
    public class ModifiedCashTransaction : BaseEntity {
        public string CashAccount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionCode { get; set; }
        public CashTransactionType TransactionType { get; set; }
        public string Folio { get; set; }
        public string Currency { get; set; }
        public decimal FxAmount { get; set; }
        public decimal Amount { get; set; }
        public string TransferredFrom { get; set; }
        public decimal Balance { get; set; }
        public string TransferredBy { get; set; }
        public string ModCashAccount { get; set; }
        public DateTime ModTransactionDate { get; set; }
        public string ModTransactionCode { get; set; }
        public CashTransactionType ModTransactionType { get; set; }
        public string ModFolio { get; set; }
        public string ModCurrency { get; set; }
        public decimal ModFxAmount { get; set; }
        public decimal ModAmount { get; set; }
        public string ModTransferredFrom { get; set; }
        public decimal ModBalance { get; set; }
        public string ModTransferredBy { get; set; }
        public long UserId { get; set; }
        public SystemUser User { get; set; }
    }
}
